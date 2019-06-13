using Prism.Ioc;
using Prism.Logging;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using Unity;
using WpfTemplate.Base;
using WpfTemplate.Constants;
using WpfTemplate.Interfaces;
using WpfTemplate.Services;
using WpfTemplate.Views;

namespace WpfTemplate
{
    public class Bootstrapper : UnityBootstrapper
    {
        /// <summary>
        /// The shell object
        /// </summary>
        /// <returns></returns>
        protected override DependencyObject CreateShell()
        {
            Container.RegisterInstance(typeof(Window), WindowNames.ShellName, Container.Resolve<Shell>());
            return Container.Resolve<Window>(WindowNames.ShellName);
        }

        /// <summary>
        /// Initialize shell (MainWindow)
        /// </summary>
        protected override void InitializeShell()
        {
            base.InitializeShell();

            // Register views
            var regionManager = Container.Resolve<IRegionManager>();
            if (regionManager != null)
            {
                // Add right windows commands
                regionManager.RegisterViewWithRegion(RegionNames.RightWindowCommandsRegion, typeof(RightTitlebarCommands));
                // Add flyouts
                regionManager.RegisterViewWithRegion(RegionNames.FlyoutRegion, typeof(ShellSettingsFlyout));
                // Add tiles to MainRegion
                regionManager.RegisterViewWithRegion(RegionNames.MainRegion, typeof(MainRegion));
            }

            // Register services
            RegisterServices();

            Application.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configure the container
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            // Application commands
            Container.RegisterType<IApplicationCommands, ApplicationCommandsProxy>();
            // Flyout service
            Container.RegisterInstance<IFlyoutService>(Container.Resolve<FlyoutService>());
            // Localizer service
            Container.RegisterInstance(typeof(ILocalizerService),
                ServiceNames.LocalizerService,
                new LocalizerService());
        }

        /// <summary>
        /// Configure the module catalog
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            // Register ModuleA
            // moduleCatalog.AddModule(typeof(ModuleA.ModuleA));
            // Register ModuleB
            // moduleCatalog.AddModule(typeof(ModuleB.ModuleB));
        }

        /// <summary>
        /// Register services
        /// </summary>
        private void RegisterServices()
        {
            // MessageDisplayService
            Container.RegisterInstance<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService, Container.Resolve<MetroMessageDisplayService>());
        }

        /// <summary>
        /// Create logger
        /// </summary>
        /// <returns></returns>
        protected override ILoggerFacade CreateLogger()
        {
            return base.CreateLogger();
        }
    }
}