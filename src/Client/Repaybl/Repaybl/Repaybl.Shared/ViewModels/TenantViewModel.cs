using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Constants;
using Repaybl.Swag;

using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{
    class TenantViewModel : BindableBase
    {
        private ITenantClient _tenantClient;
        internal Frame _contentFrame;
        public ICommand AddTenantCommand => new DelegateCommand(OnAddTenantCommandExecute);
        public TenantViewModel(ITenantClient tenantClient)
        {
            _tenantClient = tenantClient;
            _ = GetAllTenantAsync();
        }
        private Tenant _selectedTenant;
        public Tenant SelectedTenant
        {
            get { return _selectedTenant; }
            set
            {
                _selectedTenant = value;
                if (value != null)
                {
                    _contentFrame.Navigate(typeof(PropertyDetailPage), value);
                }
                OnPropertyChanged();
            }
        }
        private async Task GetAllTenantAsync()
        {
            var tenants = await _tenantClient.GetManyAsync(userID: Globals.CurrentUserId);
            if (tenants?.Count > 0)
            {
                AllTenant = new ObservableCollection<Tenant>(tenants);
            }
            else
            {
                AllTenant = new ObservableCollection<Tenant>();
            }
        }

        private void OnAddTenantCommandExecute()
        {
            _contentFrame.Navigate(typeof(TenantDetailPage));
        }
        private ObservableCollection<Tenant> _allTenant;
        public ObservableCollection<Tenant> AllTenant
        {
            get { return _allTenant; }
            set
            {
                _allTenant = value;
                OnPropertyChanged();
            }
        }
    }
}
