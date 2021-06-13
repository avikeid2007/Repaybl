using System;

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
    public sealed partial class RoomPage : Page
    {
        public RoomPage()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;
            VM = (RoomViewModel)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(RoomViewModel));
            DataContext = VM;
            this.Loaded += PropertiesPage_Loaded;
        }

        private void PropertiesPage_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            VM._contentFrame = this.Frame;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is Room room)
            {
                VM.SetParameter(room.PropertyId, room);
            }
            else if (e.Parameter is Guid id)
            {
                VM.SetParameter(id);
            }
        }
        internal RoomViewModel VM { get; }
    }
}
