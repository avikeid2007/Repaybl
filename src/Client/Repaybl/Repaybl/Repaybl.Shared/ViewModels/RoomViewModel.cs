using System;
using System.Threading.Tasks;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Services.Abstractions;
using Repaybl.Swag;

using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{

    class RoomViewModel : BindableBase
    {
        private IPropertyClient _propertyClient;
        private IDropDownService _dropDownService;
        internal Frame _contentFrame;
        public ICommand SavePropertyCommand => new AsyncCommand(OnSavePropertyCommandAsync);
        public ICommand ResetPropertyCommand => new AsyncCommand(OnResetPropertyCommandAsync);
        public RoomViewModel(IPropertyClient propertyClient)
        {
            _propertyClient = propertyClient;
        }
        private Room _selectedRoom;

        public Room SelectedRoom
        {
            get { return _selectedRoom; }
            set
            {
                _selectedRoom = value;
                OnPropertyChanged();
            }
        }
        public void SetParameter(Guid propertyId, Room room = null)
        {
            if (room != null)
            {
                SelectedRoom = room;
            }
            if (SelectedRoom == null)
            {
                SelectedRoom = new Room() { PropertyId = propertyId, Id = Guid.NewGuid() };
            }
        }
        private async Task OnSavePropertyCommandAsync()
        {
            if (!string.IsNullOrEmpty(SelectedRoom?.RoomNo))
            {
                await _propertyClient.SaveRoomAsync(SelectedRoom);
            }
        }
        private async Task OnResetPropertyCommandAsync()
        {
            throw new NotImplementedException();
        }
    }

}
