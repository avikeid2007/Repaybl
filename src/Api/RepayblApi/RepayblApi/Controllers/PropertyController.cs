using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using RepayblApi.Core;
using RepayblApi.Models;

namespace RepayblApi.Controllers
{
    [Route("api/Property")]
    [ApiController]
    public class PropertyController : RepayblController
    {
        public PropertyController(RepayblContext context) : base(context)
        {

        }
        [HttpGet]
        public ActionResult<IEnumerable<DTOs.Property>> GetMany(Guid? userID = null, string name = null, bool isIncludeRooms = false)
        {
            IQueryable<Property> query = Context.Properties;
            if (userID != null)
            {
                query = query.Where(x => x.UserId == userID);
            }
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(x => x.Name == name);
            }
            if (isIncludeRooms)
            {
                query = query.Include(x => x.Rooms);
            }
            return query.AsEnumerable().Select(ConvertModels<DTOs.Property, Models.Property>).ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<DTOs.Property> GetProperty(Guid id)
        {
            var property = Context.Properties.SingleOrDefault(x => x.Id == id);

            if (property == null)
            {
                return NotFound();
            }
            return ConvertModels<DTOs.Property, Models.Property>(property);
            //return await Task.FromResult(ConvertModels<DTOs.User, Models.User>(user));
        }
        [HttpPost]
        public async Task<ActionResult> SavePropertyAsync(DTOs.Property property)
        {
            if (property != null)
            {
                var dbobj = await Context.Properties.SingleOrDefaultAsync(x => x.Id == property.Id);
                if (dbobj == null)
                {
                    dbobj = ConvertModels<Property, DTOs.Property>(property);
                    MapCreated(dbobj);
                    await Context.Properties.AddAsync(dbobj);
                    await Context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    MapModels(property, dbobj);
                    MapModified(dbobj);
                    Context.Properties.Update(dbobj);
                    await Context.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet("Room")]
        public ActionResult<IEnumerable<DTOs.Room>> GetRooms(Guid? propertyId = null, string roomNo = null)
        {
            IQueryable<Room> query = Context.Rooms;
            if (propertyId != null)
            {
                query = query.Where(x => x.PropertyId == propertyId);
            }
            if (!string.IsNullOrEmpty(roomNo))
            {
                query = query.Where(x => x.RoomNo == roomNo);
            }
            return query.AsEnumerable().Select(ConvertModels<DTOs.Room, Models.Room>).ToList();
        }
        [HttpPost("Room")]
        public async Task<ActionResult> SaveRoomAsync(DTOs.Room room)
        {
            if (room != null)
            {
                var dbobj = await Context.Rooms.SingleOrDefaultAsync(x => x.Id == room.Id);
                if (dbobj == null)
                {
                    dbobj = ConvertModels<Room, DTOs.Room>(room);
                    MapCreated(dbobj);
                    await Context.Rooms.AddAsync(dbobj);
                    await Context.SaveChangesAsync();
                    return Ok();
                }
                else
                {
                    MapModels(room, dbobj);
                    MapModified(dbobj);
                    Context.Rooms.Update(dbobj);
                    await Context.SaveChangesAsync();
                    return Ok();
                }
            }
            return BadRequest();
        }
    }
}
