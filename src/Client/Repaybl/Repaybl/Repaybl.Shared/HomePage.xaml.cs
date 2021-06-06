﻿using Microsoft.Extensions.DependencyInjection;

using Repaybl.ViewModels;

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
        }



        private HomeViewModel VM { get; }
    }
}
