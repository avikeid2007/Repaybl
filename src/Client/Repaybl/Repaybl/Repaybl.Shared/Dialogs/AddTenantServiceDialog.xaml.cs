using Microsoft.Extensions.DependencyInjection;

using Repaybl.Dialogs.ViewModels;

using Windows.UI.Xaml.Controls;

namespace Repaybl.Dialogs
{
    public sealed partial class AddTenantServiceDialog : ContentDialog
    {
        public AddTenantServiceDialog()
        {
            this.InitializeComponent();
            var container = ((App)App.Current).Container;
            // Request an instance of the ViewModel and set it to the DataContext
            VM = (AddTenantServiceViewModel)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(AddTenantServiceViewModel));
            DataContext = VM;
        }

        internal AddTenantServiceViewModel VM { get; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
