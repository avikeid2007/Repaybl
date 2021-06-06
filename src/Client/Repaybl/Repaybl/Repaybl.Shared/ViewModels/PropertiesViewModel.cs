using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{
    class PropertiesViewModel : BindableBase
    {
        internal Frame _contentFrame;
        public ICommand AddPropertyCommand => new DelegateCommand(OnAddPropertyCommandExecute);
        public PropertiesViewModel()
        {

        }
        private void OnAddPropertyCommandExecute()
        {
            _contentFrame.Navigate(typeof(PropertyDetailPage));
        }
    }

}
