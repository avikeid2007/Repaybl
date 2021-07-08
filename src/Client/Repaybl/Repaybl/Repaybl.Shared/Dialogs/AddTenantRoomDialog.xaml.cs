using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.Extensions.DependencyInjection;

using Repaybl.Dialogs.ViewModels;
using Repaybl.ViewModels;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace Repaybl.Dialogs
{
	public sealed partial class AddTenantRoomDialog : ContentDialog
	{
		public AddTenantRoomDialog()
		{
			this.InitializeComponent();
			var container = ((App)App.Current).Container;
			// Request an instance of the ViewModel and set it to the DataContext
			VM = (AddTenantRoomViewModel)ActivatorUtilities.GetServiceOrCreateInstance(container, typeof(AddTenantRoomViewModel));
			DataContext = VM;
		}

        internal AddTenantRoomViewModel VM { get; }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}

		private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
		{
		}
	}
}
