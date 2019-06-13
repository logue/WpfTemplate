using Prism.Logging;
using Unity;
using WpfTemplate.Base;
using WpfTemplate.Events;
namespace WpfTemplate.ViewModels
{
    internal class MainRegionViewModel : ViewModelBase
    {
        /// <summary>
        /// CTOR
        /// </summary>
        public MainRegionViewModel()
        {
            // Register to events
            EventAggregator.GetEvent<StatusBarMessageUpdateEvent>().Subscribe(OnStatusBarMessageUpdateEvent);

            Container.Resolve<ILoggerFacade>().Log("MainRegionViewModel created", Category.Info, Priority.None);
        }

        #region Event-Handler

        /// <summary>
        /// EventHandler for the update status bar event
        /// </summary>
        /// <param name="statusBarMessage"></param>
        private void OnStatusBarMessageUpdateEvent(string statusBarMessage)
        {
            StatusBarMessage = statusBarMessage;
        }

        #endregion Event-Handler

        #region Properties

        private string _statusBarMessage;

        /// <summary>
        /// Status-Bar message
        /// </summary>
        public string StatusBarMessage
        {
            get => _statusBarMessage;
            set => SetProperty<string>(ref _statusBarMessage, value);
        }

        #endregion Properties
    }
}