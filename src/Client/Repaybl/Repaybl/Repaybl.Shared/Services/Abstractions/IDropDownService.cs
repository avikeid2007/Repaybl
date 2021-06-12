using System.Collections.Generic;
using System.Threading.Tasks;

using Repaybl.Swag;

namespace Repaybl.Services.Abstractions
{
    interface IDropDownService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<IEnumerable<State>> GetAllStatesAsync(int id);
    }
}
