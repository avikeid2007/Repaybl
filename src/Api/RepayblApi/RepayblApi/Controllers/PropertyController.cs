using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<DTOs.Property>> GetMany()
        {
            return Context.Properties.AsEnumerable().Select(ConvertModels<DTOs.Property, Models.Property>).ToList();
            //return await Task.FromResult(ConvertModels<DTOs.User, Models.User>(user));
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
    }
}
