using Prism.Mvvm;
using System.Windows.Media;

namespace WpfTemplate.Model
{
    public class AccentColor : BindableBase
    {
        private string _name;

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get => _name;
            set => SetProperty<string>(ref _name, value);
        }

        private Brush _colorBrush;

        /// <summary>
        /// The color brush
        /// </summary>
        public Brush ColorBrush
        {
            get => _colorBrush;
            set => SetProperty<Brush>(ref _colorBrush, value);
        }
    }
}