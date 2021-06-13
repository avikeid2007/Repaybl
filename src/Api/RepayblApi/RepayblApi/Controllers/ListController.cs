using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using RepayblApi.Geo;

namespace RepayblApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ListController : ControllerBase
    {
        private IGeoClient _geoClient;
        public ListController(IGeoClient geoClient)
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
    }
}
