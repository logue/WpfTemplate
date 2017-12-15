using Autofac;
using Prism.Autofac;
using System.Windows;
using WpfTemplate.Views;

namespace WpfTemplate
{
    class Bootstrapper : AutofacBootstrapper
    {
        protected override DependencyObject CreateShell()
            => Container.Resolve<MainWindow>();

        protected override void InitializeShell()
            => Application.Current.MainWindow.Show();
    }
}
