using Prism.Commands;
using Prism.Logging;
using System.Windows.Input;
using Unity;
using WpfTemplate.Base;
using WpfTemplate.Constants;
using WpfTemplate.Interfaces;
using WpfTemplate.Model;

namespace WpfTemplate.ViewModels
{
    public class RightTitlebarCommandsViewModel : ViewModelBase
    {
        public RightTitlebarCommandsViewModel()
        {
            // Initialize commands
            IntializeCommands();

            Container.Resolve<ILoggerFacade>().Log("RightTitlebarCommandsViewModel created", Category.Info, Priority.None);
        }

        /// <summary>
        /// Initialize commands
        /// </summary>
        private void IntializeCommands()
        {
            ShowAboutDialogCommand = new DelegateCommand(ShowAboutDialog, CanShowAboutDialog);
        }

        /// <summary>
        /// Show About Dialog
        /// </summary>
        public ICommand ShowAboutDialogCommand { get; private set; }

        public bool CanShowAboutDialog()
        {
            return true;
        }

        /// <summary>
        /// Show message
        /// </summary>
        public void ShowAboutDialog()
        {
            AppAssembly Assembly = new AppAssembly();
            Container.Resolve<IMetroMessageDisplayService>(ServiceNames.MetroMessageDisplayService).ShowMessageAsnyc(
                Assembly.Title + " v" + Assembly.Version, Assembly.Description
            );
        }
    }

}