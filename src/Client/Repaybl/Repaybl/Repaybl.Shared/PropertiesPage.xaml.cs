using Microsoft.Extensions.DependencyInjection;

using Repaybl.ViewModels;

using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Repaybl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PropertiesPage : Page
    {
        public PropertiesPage()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;
            // Request an instance of the ViewModel and set it to the DataContext
            VM = (PropertiesViewModel)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(PropertiesViewModel));
            DataContext = VM;
            this.Loaded += PropertiesPage_Loaded;
        }

        private void PropertiesPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            VM._contentFrame = this.Frame;
        }


        internal PropertiesViewModel VM { get; }
    }
}
