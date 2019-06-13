using Prism.Logging;
using Unity;
using WpfTemplate.Base;
using WpfTemplate.Events;
using WpfTemplate.Model;

namespace WpfTemplate.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public ShellViewModel()
        {
            // Register to events
            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);

            // Make window title to Assembly title.
            AppAssembly Assembly = new AppAssembly();
            _title = Assembly.Title;
            _statusText = Assembly.Description;

            Container.Resolve<ILoggerFacade>().Log("ShellViewModel created", Category.Info, Priority.None);
        }

        #region Event-Handler
        /// <summary>
        /// EventHandler for the update status bar event
        /// </summary>
        /// <param name="statusBarMessage"></param>
        private void OnStatusBarMessageUpdateEvent(string statusBarMessage)
        {
            StatusBarMessage = _statusBarMessage;
        }
        #endregion Event-Handler

        #region Properties
        private string _title = "Prism Application";

        /// <summary>
        /// Shell Window Title
        /// </summary>
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _statusText = "PrismMahApps Template Application";
        /// <summary>
        /// Status Text
        /// </summary>
        public string StatusText
        {
            get => _statusText;
            set => SetProperty<string>(ref _statusText, value);
        }

        private string _statusBarMessage;

        /// <summary>
        /// StatusBar Message
        /// </summary>
        public string StatusBarMessage
        {
            get => _statusBarMessage;
            set => SetProperty<string>(ref _statusBarMessage, value);
        }
        #endregion Properties
    }
}