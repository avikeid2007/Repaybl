using System.Threading.Tasks;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Constants;
using Repaybl.Swag;

using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{
    class PropertyDetailViewModel : BindableBase
    {
        private IPropertyClient _propertyClient;
        internal Frame _contentFrame;
        public ICommand SavePropertyCommand => new AsyncCommand(OnSavePropertyCommandAsync);
        public PropertyDetailViewModel(IPropertyClient propertyClient)
        {
            _propertyClient = propertyClient;
            SelectedProperty = new Property() { UserId = Globals.CurrentUserId };

        }
        private async Task OnSavePropertyCommandAsync()
        {
            await _propertyClient.SavePropertyAsync(SelectedProperty);
        }

        private Property _selectedProperty;
        //private Room _selectedRoom;
        //private ObservableCollection<Room> _allRoom;
        public Property SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                _selectedProperty = value;
                OnPropertyChanged();
            }
        }
        //public Room SelectedRoom
        //{
        //    get { return _selectedRoom; }
        //    set
        //    {
        //        _selectedRoom = value;
        //        RaisePropertyChanged();
        //    }
        //}
        //public ObservableCollection<Room> AllRoom
        //{
        //    get { return _allRoom; }
        //    set
        //    {
        //        _allRoom = value;
        //        RaisePropertyChanged();
        //    }
        //}
    }
}
