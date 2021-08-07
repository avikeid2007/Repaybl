using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Repaybl.Swag;

namespace Repaybl.Services.Abstractions
{
    interface IDropDownService
    {
        Task<IEnumerable<Country>> GetAllCountriesAsync();
        Task<IEnumerable<State>> GetAllStatesAsync(int id);
        Task<IEnumerable<string>> GetIDTypesAsync();
    }
    interface IPopupService
    {
        Task AddTenantRoomDialogAsync(Guid tenantId);
        Task AddTenantServiceDialogAsync(Tenant tenant);
    }
}
