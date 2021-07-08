
using System;
using System.Threading.Tasks;

using Repaybl.Dialogs;
using Repaybl.Services.Abstractions;

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
    }
}
