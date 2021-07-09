using Microsoft.Extensions.DependencyInjection;

using Repaybl.ViewModels;

using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Repaybl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;
            // Request an instance of the ViewModel and set it to the DataContext
            VM = (HomeViewModel)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(HomeViewModel));
            DataContext = VM;
            // VM.GetMainFrame(this.Frame);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
            SystemNavigationManager.GetForCurrentView().BackRequested += (s, es) =>
            {
                if (ContentFrame.CanGoBack)
                {
                    ContentFrame.GoBack();
                }
                // Handle the Back pressed
            };
        }



        private HomeViewModel VM { get; }
    }
}
