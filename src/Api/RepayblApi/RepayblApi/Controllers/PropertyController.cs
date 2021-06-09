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
            var dbobj = ConvertModels<Property, DTOs.Property>(property);
            MapCreated(dbobj);
            await Context.Properties.AddAsync(dbobj);
            await Context.SaveChangesAsync();
            return Ok();
        }
        [HttpGet("Rooms")]
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
    }
}
