using System.Windows.Media;
using Prism.Mvvm;

namespace WpfTemplate.Base {
    public abstract class ViewModelDialogPopupBase : BindableBase {
        /// <summary>
        /// View title
        /// </summary>
        public abstract string Title { get; }

        /// <summary>
        /// The dialog icon
        /// </summary>
        public abstract ImageSource Icon { get; }
    }
}