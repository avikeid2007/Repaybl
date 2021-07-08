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

namespace Repaybl.Dialogs.ViewModels
{
    class AddTenantRoomViewModel : BindableBase
    {
        private List<Property> _properties;
        private ObservableCollection<Room> _rooms;
        private Property _selectedProperty;
        private Room _selectedRoom;
        private IPropertyClient _propertyClient;
        private IPopupService _popupService;
        public Guid? TenantId { get; internal set; }
        public AddTenantRoomViewModel(IPropertyClient propertyClient, IPopupService popupService)
        {
            _propertyClient = propertyClient;
            _popupService = popupService;
            _ = GetAllPropertiesAsync();
        }
        public ICommand AddRoomCommand => new AsyncCommand(OnAddRoomCommandAsync);
        private async Task OnAddRoomCommandAsync()
        {
            var rooms = Rooms.Where(x => x.IsSelected).ToList();
            if (rooms?.Count > 0 && TenantId != null)
            {
                rooms.ForEach(x => x.CurrentTenantId = TenantId);
                await _propertyClient.UpdateRoomAsync(rooms);
            }
        }
        private async Task GetAllPropertiesAsync()
        {
            var properties = await _propertyClient.GetManyAsync(userID: Globals.CurrentUserId, isIncludeRooms: true);
            if (properties?.Count > 0)
            {
                Properties = new List<Property>(properties);
            }
            else
            {
                Properties = new List<Property>();
            }
        }
        public List<Property> Properties
        {
            get { return _properties; }
            set
            {
                _properties = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Room> Rooms
        {
            get { return _rooms; }
            set
            {
                _rooms = value;
                OnPropertyChanged();
            }
        }
        public Property SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                _selectedProperty = value;
                if (value != null)
                {
                    Rooms?.Clear();
                    Rooms = new ObservableCollection<Room>(value.Rooms.Where(x => x.CurrentTenantId == null));
                }
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


    }
}