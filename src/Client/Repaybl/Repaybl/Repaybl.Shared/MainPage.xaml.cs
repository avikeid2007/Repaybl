
using Microsoft.Extensions.DependencyInjection;

using Repaybl.ViewModels;

using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Repaybl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MainViewModel VM { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;
            // Request an instance of the ViewModel and set it to the DataContext
            VM = (MainViewModel)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(MainViewModel));
            DataContext = VM;
            this.Loaded += PropertiesPage_Loaded;
        }
        private void PropertiesPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            VM._contentFrame = this.Frame;
        }


    }
}
