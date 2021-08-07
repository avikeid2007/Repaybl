using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Services.Abstractions;
using Repaybl.Swag;

namespace Repaybl.Dialogs.ViewModels
{
    class AddTenantServiceViewModel : BindableBase
    {
        private List<Service> _services;
        private Tenant _selectedTenant;
        private List<BillingType> _billingTypes;
        private BillingType _selectedBillingType;
        private Service _selectedService;
        private Room _selectedRoom;
        private TenantService _selectedTenantService;
        private ITenantClient _tenantClient;
        private IPopupService _popupService;
        private ObservableCollection<TenantService> _myServices;
        public ObservableCollection<TenantService> MyServices
        {
            get { return _myServices; }
            set
            {
                _myServices = value;
                OnPropertyChanged();
            }
        }
        public AddTenantServiceViewModel(ITenantClient tenantClient, IPopupService popupService, IListClient listClient)
        {
            _tenantClient = tenantClient;
            _popupService = popupService;
            _ = GetAllDropDrownAsync(listClient);
        }

        private async Task GetAllDropDrownAsync(IListClient listClient)
        {
            Services = new List<Service>(await listClient.GetServiesAsync());
            BillingTypes = new List<BillingType>(Enum.GetValues(typeof(BillingType)).Cast<BillingType>());
        }

        public ICommand AddServiceCommand => new AsyncCommand(OnAddServiceCommandAsync);
        public ICommand AddNewServiceCommand => new AsyncCommand(OnAddNewServiceCommandAsync);

        private async Task OnAddNewServiceCommandAsync()
        {
            if (SelectedService == null || SelectedRoom == null || SelectedTenant == null)
            {
                return;
            }
            if (MyServices == null)
            {
                MyServices = new ObservableCollection<TenantService>();
            }
            var ser = new TenantService
            {
                Id = Guid.NewGuid(),
                BillType = SelectedBillingType,
                FixedAmount = Convert.ToDecimal(Amount),
                ServiceId = SelectedService.Id,
                Service = SelectedService,
                TenantId = SelectedTenant.Id,
                RoomId = SelectedRoom.Id,
                Room = SelectedRoom
            };
            MyServices.Add(ser);
            SelectedService = null;
            Amount = string.Empty;
        }

        private async Task OnAddServiceCommandAsync()
        {

            if (MyServices?.Count > 0)
            {
                await _tenantClient.SaveTenantServicesAsync(MyServices);
            }
        }
        private string _amount;
        public string Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                OnPropertyChanged();
            }
        }
        public TenantService SelectedTenantService
        {
            get { return _selectedTenantService; }
            set
            {
                _selectedTenantService = value;
                OnPropertyChanged();
            }
        }
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged();
            }
        }
        public List<Service> Services
        {
            get { return _services; }
            set
            {
                _services = value;
                OnPropertyChanged();
            }
        }
        public Tenant SelectedTenant
        {
            get { return _selectedTenant; }
            set
            {
                _selectedTenant = value;
                OnPropertyChanged();
            }
        }
        public List<BillingType> BillingTypes
        {
            get { return _billingTypes; }
            set
            {
                _billingTypes = value;
                OnPropertyChanged();
            }
        }
        public BillingType SelectedBillingType
        {
            get { return _selectedBillingType; }
            set
            {
                _selectedBillingType = value;
                OnPropertyChanged();
            }
        }
        public Service SelectedService
        {
            get { return _selectedService; }
            set
            {
                _selectedService = value;
                OnPropertyChanged();
            }
        }
    }
}
