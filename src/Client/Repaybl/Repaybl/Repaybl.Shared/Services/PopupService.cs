
using System;
using System.Threading.Tasks;

using Repaybl.Dialogs;
using Repaybl.Services.Abstractions;
using Repaybl.Swag;

namespace Repaybl.Services
{
    class PopupService : IPopupService
    {
        public async Task AddTenantRoomDialogAsync(Guid tenantId)
        {
            var dialog = new AddTenantRoomDialog();
            dialog.VM.TenantId = tenantId;
            await dialog.ShowAsync();
        }

        public async Task AddTenantServiceDialogAsync(Tenant tenant)
        {
            var dialog = new AddTenantServiceDialog();
            dialog.VM.SelectedTenant = tenant;
            await dialog.ShowAsync();
        }
    }
}
