
using System.Collections.Generic;
using System.Threading.Tasks;

using Repaybl.Services.Abstractions;
using Repaybl.Swag;

namespace Repaybl.Services
{
    class DropDownService : IDropDownService
    {
        private IListClient _listClient;
        public DropDownService(IListClient listClient)
        {
            _listClient = listClient;
        }
        public async Task<IEnumerable<Country>> GetAllCountriesAsync()
        {
            return await _listClient.GetCountriesAsync();
        }
        public async Task<IEnumerable<State>> GetAllStatesAsync(int id)
        {
            return await _listClient.GetStatesAsync(id);
        }
        public async Task<IEnumerable<string>> GetIDTypesAsync()
        {
            return await _listClient.GetIDTypesAsync();
        }
    }
}
