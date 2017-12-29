using System.Windows.Media;
using Prism.Mvvm;

namespace WpfTemplate.Model {
    public class ApplicationTheme : BindableBase {
        private string _name;

        /// <summary>
        /// Name
        /// </summary>
        public string Name {
            get { return _name; }
            set { SetProperty<string> (ref _name, value); }
        }

        private Brush _colorBrush;

        /// <summary>
        /// The color brush
        /// </summary>
        public Brush ColorBrush {
            get { return _colorBrush; }
            set { SetProperty<Brush> (ref _colorBrush, value); }
        }

        private Brush _borderColorBrush;

        /// <summary>
        /// The border color brush
        /// </summary>
        public Brush BorderColorBrush {
            get { return _borderColorBrush; }
            set { SetProperty<Brush> (ref _borderColorBrush, value); }
        }
    }
}