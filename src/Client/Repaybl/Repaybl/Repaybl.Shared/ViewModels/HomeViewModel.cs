
using System;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Constants;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{
    class HomeViewModel : BindableBase
    {
        internal Frame _contentFrame;
        public ICommand ItemInvokedCommand => new DelegateCommand<NavigationViewItemInvokedEventArgs>(OnItemInvokedCommandExecute);
        public ICommand LoadCommand => new DelegateCommand<object>(OnLoadCommandExecute);
        public HomeViewModel()
        {


        }
        private void OnLoadCommandExecute(object obj)
        {
            if (obj is Frame contentFrame)
            {
                _contentFrame = contentFrame;
                _contentFrame.Navigate(typeof(PropertiesPage));
            }
        }
        private void OnItemInvokedCommandExecute(NavigationViewItemInvokedEventArgs obj)
        {
            if (_contentFrame != null)
            {
                if (obj.IsSettingsInvoked)
                {
                    ToggleTheme();
                }
                else if (obj.InvokedItemContainer is NavigationViewItem item && Enum.TryParse(item.Content.ToString(), out PageTokens token))
                {
                    switch (token)
                    {
                        case PageTokens.Properties:
                            _contentFrame.Navigate(typeof(PropertiesPage));
                            break;
                        case PageTokens.Tenants:
                            _contentFrame.Navigate(typeof(PropertiesPage));
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        private void ToggleTheme()
        {
            // Set theme for window root.
            if (Window.Current.Content is FrameworkElement frameworkElement)
            {
                if (frameworkElement.ActualTheme == ElementTheme.Dark)
                {
                    frameworkElement.RequestedTheme = ElementTheme.Light;
                }
                else
                {
                    frameworkElement.RequestedTheme = ElementTheme.Dark;
                }
            }
        }
    }
}
