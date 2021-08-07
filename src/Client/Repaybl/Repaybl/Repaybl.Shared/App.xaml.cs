using System;
using System.Linq;
using System.Security.Claims;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Repaybl.Constants;
using Repaybl.Helpers;
using Repaybl.Services;
using Repaybl.Services.Abstractions;
using Repaybl.Swag;

using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Repaybl
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App : Application
    {
#if NET5_0 && WINDOWS
        private Window _window;

#else
        private Windows.UI.Xaml.Window _window;
#endif

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
#if __IOS__ || __ANDROID__
    Uno.UI.FeatureConfiguration.Style.ConfigureNativeFrameNavigation();
#endif
            InitializeLogging();

            this.InitializeComponent();

#if HAS_UNO || NETFX_CORE
            this.Suspending += OnSuspending;
#endif
            Container = ConfigureDependencyInjection();
        }

        public IServiceProvider Container { get; }

        IServiceProvider ConfigureDependencyInjection()
        {
            var serviceCollection = new ServiceCollection();

            // TODO - Register dependencies
            serviceCollection.AddTransient<IPropertyClient, PropertyClient>();
            serviceCollection.AddTransient<IUserClient, UserClient>();
            serviceCollection.AddTransient<IListClient, ListClient>();
            serviceCollection.AddTransient<ITenantClient, TenantClient>();
            serviceCollection.AddTransient<IDropDownService, DropDownService>();
            serviceCollection.AddTransient<IPopupService, PopupService>();
            // Build the IServiceProvider and return it
            return serviceCollection.BuildServiceProvider();
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            //this.Resources.MergedDictionaries.Add(new global::Uno.Material.MaterialColorPalette());

            //// Overlap the default colors with the application's colors palette.
            //// TODO: Replace ms-appx:///Views/ColorPaletteOverride.xaml with your resourceDictionary.
            //this.Resources.MergedDictionaries.Add(new ResourceDictionary() { Source = new Uri("ms-appx:///Styles/ColorPaletteOverride.xaml") });

            //// Add all the material resources. Those resources depend on the colors above, which is why this one must be added last.
            //this.Resources.MergedDictionaries.Add(new global::Uno.Material.MaterialResources());
#if DEBUG
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // this.DebugSettings.EnableFrameRateCounter = true;
            }
#endif

#if NET5_0 && WINDOWS
            _window = new Window();
            _window.Activate();
#else
            _window = Windows.UI.Xaml.Window.Current;
#endif
#if __ANDROID__
            Uno.UI.FeatureConfiguration.Popup.UseNativePopup = false;
#endif
            var rootFrame = _window.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                _window.Content = rootFrame;
            }

#if !(NET5_0 && WINDOWS)
            if (e.PrelaunchActivated == false)
#endif
            {
                if (rootFrame.Content == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    if (IsLoginNeeded())
                        rootFrame.Navigate(typeof(MainPage), e.Arguments);
                    else
                        rootFrame.Navigate(typeof(HomePage), e.Arguments);
                }

                _window.Activate();
            }
        }

        private bool IsLoginNeeded()
        {
            try
            {
                var res = LocalSettingHelper.GetContainerValue<string>("token");
                if (string.IsNullOrEmpty(res))
                {
                    return true;
                }
                var claims = ServiceExtensions.ParseClaimsFromJwt(res);
                Globals.CurrentUserId = Guid.Parse(claims.First(x => x.Type == ClaimTypes.NameIdentifier)?.Value);
                Globals.CurrentUserEmail = claims.First(x => x.Type == ClaimTypes.Email)?.Value;
                Globals.CurrentUserName = claims.First(x => x.Type == ClaimTypes.Name)?.Value;
                BaseClient.SetBearerToken(res);
                return false;
            }
            catch (Exception ex)
            {
                return true;
            }
        }
        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception($"Failed to load {e.SourcePageType.FullName}: {e.Exception}");
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        /// <summary>
        /// Configures global Uno Platform logging
        /// </summary>
        private static void InitializeLogging()
        {
            var factory = LoggerFactory.Create(builder =>
            {
#if __WASM__
                builder.AddProvider(new global::Uno.Extensions.Logging.WebAssembly.WebAssemblyConsoleLoggerProvider());
#elif __IOS__
                builder.AddProvider(new global::Uno.Extensions.Logging.OSLogLoggerProvider());
#elif NETFX_CORE
                builder.AddDebug();
#else
                builder.AddConsole();
#endif

                // Exclude logs below this level
                builder.SetMinimumLevel(LogLevel.Information);

                // Default filters for Uno Platform namespaces
                builder.AddFilter("Uno", LogLevel.Warning);
                builder.AddFilter("Windows", LogLevel.Warning);
                builder.AddFilter("Microsoft", LogLevel.Warning);

                // Generic Xaml events
                // builder.AddFilter("Windows.UI.Xaml", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.VisualStateGroup", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.StateTriggerBase", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.UIElement", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.FrameworkElement", LogLevel.Trace );

                // Layouter specific messages
                // builder.AddFilter("Windows.UI.Xaml.Controls", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.Controls.Layouter", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.Controls.Panel", LogLevel.Debug );

                // builder.AddFilter("Windows.Storage", LogLevel.Debug );

                // Binding related messages
                // builder.AddFilter("Windows.UI.Xaml.Data", LogLevel.Debug );
                // builder.AddFilter("Windows.UI.Xaml.Data", LogLevel.Debug );

                // Binder memory references tracking
                // builder.AddFilter("Uno.UI.DataBinding.BinderReferenceHolder", LogLevel.Debug );

                // RemoteControl and HotReload related
                // builder.AddFilter("Uno.UI.RemoteControl", LogLevel.Information);

                // Debug JS interop
                // builder.AddFilter("Uno.Foundation.WebAssemblyRuntime", LogLevel.Debug );
            });

            global::Uno.Extensions.LogExtensionPoint.AmbientLoggerFactory = factory;
        }
    }
}
