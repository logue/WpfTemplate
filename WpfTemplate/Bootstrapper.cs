using WpfTemplate.Views;
using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;

namespace WpfTemplate
{
    class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell() => Container.Resolve<MainWindow>();

        protected override void InitializeShell()
        {
            Application.Current.MainWindow.Show();
        }
    }
}
