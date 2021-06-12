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
    class PropertiesViewModel : BindableBase
    {
        private IPropertyClient _propertyClient;
        internal Frame _contentFrame;
        public ICommand AddPropertyCommand => new DelegateCommand(OnAddPropertyCommandExecute);
        public PropertiesViewModel(IPropertyClient propertyClient)
        {
            _propertyClient = propertyClient;
            _ = GetAllPropertiesAsync();
        }
        private Property _selectedProperty;
        public Property SelectedProperty
        {
            get { return _selectedProperty; }
            set
            {
                _selectedProperty = value;
                if (value != null)
                {
                    _contentFrame.Navigate(typeof(PropertyDetailPage), value);
                }
                OnPropertyChanged();
            }
        }
        private async Task GetAllPropertiesAsync()
        {
            var properties = await _propertyClient.GetManyAsync(userID: Globals.CurrentUserId, isIncludeRooms: true);
            if (properties?.Count > 0)
            {
                AllProperty = new ObservableCollection<Property>(properties);
            }
            else
            {
                AllProperty = new ObservableCollection<Property>();
            }
        }

        private void OnAddPropertyCommandExecute()
        {
            _contentFrame.Navigate(typeof(PropertyDetailPage));
        }
        private ObservableCollection<Property> _allProperty;
        public ObservableCollection<Property> AllProperty
        {
            get { return _allProperty; }
            set
            {
                _allProperty = value;
                OnPropertyChanged();
            }
        }
    }

}
