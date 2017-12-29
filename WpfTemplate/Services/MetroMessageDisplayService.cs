using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Unity;
using System.Threading.Tasks;
using System.Windows;
using WpfTemplate.Constants;
using WpfTemplate.Interfaces;

namespace WpfTemplate.Services
{
    public class MetroMessageDisplayService : IMetroMessageDisplayService {
        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="container">Unity container.</param>
        public MetroMessageDisplayService (IUnityContainer container) {
            Shell = container.Resolve<Window> (WindowNames.ShellName) as MetroWindow;
        }

        #region Properties

        private MetroWindow _shell;

        /// <summary>
        /// The main window
        /// </summary>
        public MetroWindow Shell {
            get { return _shell; }
            private set { _shell = value; }
        }

        #endregion Properties

        public async Task<MessageDialogResult> ShowMessageAsnyc (string title, string message, MessageDialogStyle style = MessageDialogStyle.Affirmative, MetroDialogSettings settings = null) {
            Shell.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;

            return await Shell.ShowMessageAsync (title, message, style, Shell.MetroDialogOptions);
        }

    }
}