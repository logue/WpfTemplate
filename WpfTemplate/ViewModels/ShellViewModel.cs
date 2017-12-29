using Microsoft.Practices.Unity;
using Prism.Logging;
using WpfTemplate.Base;
using WpfTemplate.Events;

namespace WpfTemplate.ViewModels
{
    public class ShellViewModel : ViewModelBase {
        /// <summary>
        /// CTOR
        /// </summary>
        public ShellViewModel () {
            // Register to events
            EventAggregator.GetEvent<StatusBarMessageUpdateEvent> ().Subscribe (OnStatusBarMessageUpdateEvent);

            Container.Resolve<ILoggerFacade> ().Log ("ShellViewModel created", Category.Info, Priority.None);
        }

        #region Event-Handler
        /// <summary>
        /// EventHandler for the update status bar event
        /// </summary>
        /// <param name="statusBarMessage"></param>
        private void OnStatusBarMessageUpdateEvent (string statusBarMessage) {
            StatusBarMessage = _statusBarMessage;
        }

        #endregion Event-Handler

        #region Properties
        private string _title = "Prism Application";

        /// <summary>
        /// Shell Window Title
        /// </summary>
        public string Title {
            get { return _title; }
            set { SetProperty (ref _title, value); }
        }

        private string _statusBarMessage;

        /// <summary>
        /// Status-Bar message
        /// </summary>
        public string StatusBarMessage {
            get { return _statusBarMessage; }
            set { SetProperty<string> (ref _statusBarMessage, value); }
        }

        #endregion Properties
    }
}