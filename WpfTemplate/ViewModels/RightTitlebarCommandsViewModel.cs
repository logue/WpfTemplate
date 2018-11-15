using Prism.Commands;
using System.Windows.Input;
using Unity;
using WpfTemplate.Base;
using WpfTemplate.Constants;
using WpfTemplate.Interfaces;
using WpfTemplate.Model;

namespace WpfTemplate.ViewModels
{
    public class RightTitlebarCommandsViewModel : ViewModelBase {
        public RightTitlebarCommandsViewModel () {
            // Initialize commands
            IntializeCommands ();
        }

        /// <summary>
        /// Initialize commands
        /// </summary>
        private void IntializeCommands () {
            ShowAboutDialogCommand = new DelegateCommand (ShowAboutDialog, CanShowAboutDialog);
        }

        /// <summary>
        /// Show About Dialog
        /// </summary>
        public ICommand ShowAboutDialogCommand { get; private set; }

        public bool CanShowAboutDialog () {
            return true;
        }

        /// <summary>
        /// Show message
        /// </summary>
        public void ShowAboutDialog () {
            var assembly = new AppAssembly ();
            Container.Resolve<IMetroMessageDisplayService> (ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc (
                assembly.Title, "Version :" + assembly.Version
            );
        }
    }

}