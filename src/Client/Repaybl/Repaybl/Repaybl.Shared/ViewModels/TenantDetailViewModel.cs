using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Constants;
using Repaybl.Services.Abstractions;
using Repaybl.Swag;

using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{
    class TenantDetailViewModel : BindableBase
    {

        private ITenantClient _tenantClient;
        private IDropDownService _dropDownService;
        internal Frame _contentFrame;
        private IPopupService _popupService;
        private IPropertyClient _propertyClient;
        public ICommand SaveTenantCommand => new AsyncCommand(OnSaveTenantCommandAsync);
        public ICommand ResetTenantCommand => new AsyncCommand(OnResetTenantCommandAsync);
        public ICommand AddRoomCommand => new AsyncCommand(OnAddRoomCommandAsync);

        private async Task OnAddRoomCommandAsync()
        {
            await _popupService.AddTenantRoomDialogAsync(SelectedTenant.Id);
        }

        public TenantDetailViewModel(ITenantClient tenantClient, IPropertyClient propertyClient, IDropDownService dropDownService, IPopupService popupService)
        {
            _tenantClient = tenantClient;
            _dropDownService = dropDownService;
            _popupService = popupService;
            _propertyClient = propertyClient;
            SelectedTenant = new Tenant() { UserId = Globals.CurrentUserId, Id = Guid.NewGuid(), Doj = DateTimeOffset.Now };
            _ = FillDropdownAsync();
        }
        public void SetParameter(Tenant property)
        {
            if (property != null)
            {
                SelectedTenant = property;
                IsExistUser = true;
            }
        }
        private async Task FillStatesDropdownAsync(Country value)
        {
            AllStates = new List<State>(await _dropDownService.GetAllStatesAsync(value.Id));
            if (!string.IsNullOrEmpty(SelectedTenant?.State))
            {
                SelectedState = AllStates?.FirstOrDefault(x => x.Name.Equals(SelectedTenant.State));
            }
        }
        private async Task FillRoomsAsync()
        {
            if (IsExistUser)
                await _propertyClient.GetRoomsAsync(tenantId: SelectedTenant.Id);
        }
        private async Task FillDropdownAsync()
        {
            IDTypes = new List<string>(await _dropDownService.GetIDTypesAsync());
            AllCountries = new List<Country>(await _dropDownService.GetAllCountriesAsync());
            if (!string.IsNullOrEmpty(SelectedTenant?.Country))
            {
                SelectedCountry = AllCountries?.FirstOrDefault(x => x.Name.Equals(SelectedTenant.Country));
            }
        }

        private async Task OnSaveTenantCommandAsync()
        {
            if (!string.IsNullOrEmpty(SelectedTenant?.FirstName))
            {
                await _tenantClient.SaveTenantAsync(SelectedTenant);
            }
        }
        private async Task OnResetTenantCommandAsync()
        {
            throw new NotImplementedException();
        }
        private Tenant _selectedTenant;
        private Room _selectedRoom;
        private ObservableCollection<Room> _allRoom;
        private List<Country> _allCountries;
        private List<State> _allStates;
        private Country _selectedCountry;
        private State _selectedState;
        private List<string> _iDTypes;
        private string _selectedId;
        private bool _isExistUser;
        public bool IsExistUser
        {
            get { return _isExistUser; }
            set
            {
                _isExistUser = value;
                OnPropertyChanged();
            }
        }
        public List<string> IDTypes
        {
            get { return _iDTypes; }
            set
            {
                _iDTypes = value;
                OnPropertyChanged();
            }
        }
        public string SelectedId
        {
            get { return _selectedId; }
            set
            {
                _selectedId = value;
                OnPropertyChanged();
            }
        }
        public Country SelectedCountry
        {
            get { return _selectedCountry; }
            set
            {
                if (_selectedCountry != value)
                {
                    _selectedCountry = value;
                    if (value != null)
                    {
                        SelectedTenant.Country = value.Name;
                        _ = FillStatesDropdownAsync(value);
                    }
                    OnPropertyChanged();
                }
            }
        }


        public State SelectedState
        {
            get { return _selectedState; }
            set
            {
                if (_selectedState != value)
                {
                    _selectedState = value;
                    SelectedTenant.State = value.Name;
                    OnPropertyChanged();
                }
            }
        }
        public List<Country> AllCountries
        {
            get { return _allCountries; }
            set
            {
                _allCountries = value;
                OnPropertyChanged();
            }
        }
        public List<State> AllStates
        {
            get { return _allStates; }
            set
            {
                _allStates = value;
                OnPropertyChanged();
            }
        }
        public Tenant SelectedTenant
        {
            get { return _selectedTenant; }
            set
            {
                if (_selectedTenant != value)
                {
                    _selectedTenant = value;
                    OnPropertyChanged();
                }
            }
        }
        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                //if (value != null)
                //{
                //    _contentFrame.Navigate(typeof(RoomPage), value);
                //}
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Room> AllRoom
        {
            get { return _allRoom; }
            set
            {
                _allRoom = value;
                OnPropertyChanged();
            }
        }
    }
}


