using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using RepayblApi.Core;
using RepayblApi.Geo;
using RepayblApi.Models;

namespace RepayblApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ListController : RepayblController
    {
        private IGeoClient _geoClient;
        public ListController(IGeoClient geoClient, RepayblContext context) : base(context)
        {
            _geoClient = geoClient;
        }
        [HttpGet("countries")]
        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            if (string.IsNullOrEmpty(GeoBaseClient.ApiKey))
            {
                return default;
            }
            return await _geoClient.GetCountriesAsync(GeoBaseClient.ApiKey);
        }
        [HttpGet("states")]
        public async Task<IEnumerable<State>> GetStatesAsync(int id)
        {
            if (string.IsNullOrEmpty(GeoBaseClient.ApiKey))
            {
                return default;
            }
            return await _geoClient.GetStatesAsync(GeoBaseClient.ApiKey, id);

        }
        [HttpGet("IDTypes")]
        public IEnumerable<string> GetIDTypes()
        {
            yield return "Aadhar Card";
            yield return "Voter Id Card";
            yield return "Pan Card";
            yield return "Driving License";

        }
        [HttpGet("Servies")]
        public IEnumerable<DTOs.Service> GetServies()
        {
            return Context.Services.AsEnumerable().Select(ConvertModels<DTOs.Service, Models.Service>).ToList();
        }
    }
}
