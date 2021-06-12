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
    class PropertyDetailViewModel : BindableBase
    {

        private IPropertyClient _propertyClient;
        private IDropDownService _dropDownService;
        internal Frame _contentFrame;
        public ICommand SavePropertyCommand => new AsyncCommand(OnSavePropertyCommandAsync);
        public ICommand ResetPropertyCommand => new AsyncCommand(OnResetPropertyCommandAsync);
        public ICommand AddRoomCommand => new AsyncCommand(OnAddRoomCommandAsync);

        private Task OnAddRoomCommandAsync()
        {
            throw new NotImplementedException();
        }

        public PropertyDetailViewModel(IPropertyClient propertyClient, IDropDownService dropDownService)
        {
            _propertyClient = propertyClient;
            _dropDownService = dropDownService;
            SelectedProperty = new Property() { UserId = Globals.CurrentUserId, Id = Guid.NewGuid() };
            _ = FillDropdownAsync();
        }
        public void SetParameter(Property property)
        {
            if (property != null)
            {
                SelectedProperty = property;
            }
        }
        private async Task FillStatesDropdownAsync(Country value)
        {
            AllStates = new List<State>(await _dropDownService.GetAllStatesAsync(value.Id));
            if (SelectedProperty != null && !string.IsNullOrEmpty(SelectedProperty.State))
            {
                SelectedState = AllStates?.FirstOrDefault(x => x.Name.Equals(SelectedProperty.State));
            }
        }
        private async Task FillDropdownAsync()
        {
            AllCountries = new List<Country>(await _dropDownService.GetAllCountriesAsync());
            if (SelectedProperty != null && !string.IsNullOrEmpty(SelectedProperty.Country))
            {
                SelectedCountry = AllCountries?.FirstOrDefault(x => x.Name.Equals(SelectedProperty.Country));
            }
        }

        private async Task OnSavePropertyCommandAsync()
        {
            await _propertyClient.SavePropertyAsync(SelectedProperty);
        }
        private async Task OnResetPropertyCommandAsync()
        {
            throw new NotImplementedException();
        }
        private Property _selectedProperty;
        private Room _selectedRoom;
        private ObservableCollection<Room> _allRoom;
        private List<Country> _allCountries;
        private List<State> _allStates;
        private Country _selectedCountry;
        private State _selectedState;
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
                        SelectedProperty.Country = value.Name;
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
                    SelectedProperty.State = value.Name;
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
        public Property SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                if (_selectedProperty != value)
                {
                    _selectedProperty = value;
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
