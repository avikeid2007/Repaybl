
using System;
using System.Windows.Input;

using BasicMvvm;
using BasicMvvm.Commands;

using Repaybl.Constants;
using Repaybl.Helpers;
using Repaybl.Swag;

using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Repaybl.ViewModels
{
    class HomeViewModel : BindableBase
    {
        internal Frame _contentFrame;
        internal Frame _mainFrame;
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

        //internal void GetMainFrame(Frame frame)
        //{
        //    _mainFrame = frame;
        //}

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
                            _contentFrame.Navigate(typeof(TenantPage));
                            break;
                        case PageTokens.Logout:
                            LocalSettingHelper.MarkContainer("token", "");
                            BaseClient.SetBearerToken("");
                            var frame = Window.Current.Content as Frame;
                            frame.BackStack.Clear();
                            _contentFrame.BackStack.Clear();
                            //var window = App._window as Frame;
                            frame.Navigate(typeof(MainPage));
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
