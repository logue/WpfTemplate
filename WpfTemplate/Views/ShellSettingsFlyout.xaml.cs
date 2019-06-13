using MahApps.Metro.Controls;
using WpfTemplate.Constants;
using WpfTemplate.Interfaces;

namespace WpfTemplate.Views
{
    /// <summary>
    /// ShellSettingsFlyout.xaml の相互作用ロジック
    /// </summary>
    public partial class ShellSettingsFlyout : Flyout, IFlyoutView
    {
        public ShellSettingsFlyout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The flyout name
        /// </summary>
        public string FlyoutName => FlyoutNames.ShellSettingsFlyout;
    }
}
