using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RepayblApi.Core;
using RepayblApi.Models;

namespace RepayblApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TenantController : RepayblController
    {
        public TenantController(RepayblContext context) : base(context)
        {

        }
        [HttpGet]
        public ActionResult<IEnumerable<DTOs.Tenant>> GetMany(Guid? userID = null, string name = null, bool isIncludeServices = false, bool isIncludeRooms = false, bool isIncludeFamily = false)
        {
            IQueryable<Models.Tenant> query = Context.Tenants
                .Include(x => x.TenantServices)
                .Include(x => x.TenantDocuments)
                .Include(x => x.TenantOutstandings)
                .Include(x => x.Rooms);
            if (userID != null)
            {
                query = query.Where(x => x.UserId == userID);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.FirstName == name || x.LastName == name);
            }
            if (isIncludeRooms)
            {
                query = query.Include(x => x.Rooms);
            }
            if (isIncludeServices)
            {
                query = query.Include(x => x.TenantServices);
            }
            if (isIncludeFamily)
            {
                query = query.Include(x => x.FamilyDetails);
            }
            return query.AsEnumerable().Select(ConvertModels<DTOs.Tenant, Models.Tenant>).ToList();
        }
        [HttpPost]
        public async Task<ActionResult> SaveTenantAsync(DTOs.Tenant tenant)
        {
            if (tenant != null)
            {
                var dbobj = await Context.Tenants.SingleOrDefaultAsync(x => x.Id == tenant.Id);
                using (var transaction = Context.Database.BeginTransaction())
                {
                    try
                    {
                        if (dbobj == null)
                        {
                            dbobj = ConvertModels<Models.Tenant, DTOs.Tenant>(tenant);
                            MapCreated(dbobj);
                            await Context.Tenants.AddAsync(dbobj);
                            await Context.SaveChangesAsync();
                            if (tenant.RoomIds?.Count() > 0)
                            {
                                foreach (var item in tenant.RoomIds)
                                {
                                    var dbroom = await Context.Rooms.FindAsync(item);
                                    if (dbroom.CurrentTenantId == null)
                                    {
                                        dbroom.CurrentTenantId = item;
                                        Context.Rooms.Update(dbroom);
                                    }
                                    else
                                    {
                                        return BadRequest();
                                    }
                                }
                                await Context.SaveChangesAsync();
                            }
                            transaction.Commit();
                            return Ok();
                        }
                        else
                        {
                            MapModels(tenant, dbobj);
                            MapModified(dbobj);
                            Context.Tenants.Update(dbobj);
                            await Context.SaveChangesAsync();
                            if (tenant.RoomIds?.Count() > 0)
                            {
                                var currentRooms = await Context.Rooms.Where(x => x.CurrentTenantId == tenant.Id).ToListAsync();
                                if (currentRooms?.Count > 0)
                                {
                                    var roomToRelease = currentRooms.Where(x => !tenant.RoomIds.Contains(x.Id)).ToList();
                                    if (roomToRelease?.Count > 0)
                                    {
                                        roomToRelease.ForEach(x => x.CurrentTenantId = null);
                                        Context.Tenants.UpdateRange(dbobj);
                                        await Context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in tenant.RoomIds)
                                {
                                    var dbroom = await Context.Rooms.FindAsync(item);
                                    if (dbroom.CurrentTenantId == null)
                                    {
                                        dbroom.CurrentTenantId = item;
                                        Context.Rooms.Update(dbroom);
                                    }
                                    else if (dbroom.CurrentTenantId != dbroom.CurrentTenantId)
                                    {
                                        return BadRequest();
                                    }
                                }
                                await Context.SaveChangesAsync();
                            }
                            transaction.Commit();
                            return Ok();
                        }
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
            return BadRequest();
        }
        [HttpPost("TenantServices")]
        public async Task<ActionResult> SaveTenantServicesAsync(IEnumerable<DTOs.TenantService> tenantServices)
        {
            if (tenantServices?.Count() > 0)
            {
                foreach (var service in tenantServices)
                {
                    var dbobj = await Context.TenantServices.SingleOrDefaultAsync(x => x.Id == service.Id);
                    if (dbobj != null)
                    {
                        MapModels(service, dbobj);
                        MapModified(dbobj);
                        Context.TenantServices.Update(dbobj);

                    }
                    else
                    {
                        dbobj = ConvertModels<Models.TenantService, DTOs.TenantService>(service);
                        MapCreated(dbobj);
                        await Context.TenantServices.AddAsync(dbobj);

                    }
                }
                await Context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }
    }
}
