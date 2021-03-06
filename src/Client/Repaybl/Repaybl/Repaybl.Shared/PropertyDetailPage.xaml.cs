
using Microsoft.Extensions.DependencyInjection;

using Repaybl.Swag;
using Repaybl.ViewModels;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Repaybl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PropertyDetailPage : Page
    {
        public PropertyDetailPage()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;
            // Request an instance of the ViewModel and set it to the DataContext
            VM = (PropertyDetailViewModel)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(PropertyDetailViewModel));
            DataContext = VM;
            this.Loaded += PropertiesPage_Loaded;
        }

        private void PropertiesPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            VM._contentFrame = this.Frame;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Property property)
                VM.SetParameter(property);
        }
        internal PropertyDetailViewModel VM { get; }
    }
}
