using MahApps.Metro.Controls;
using Prism.Regions;
using System.Windows;
using WpfTemplate.Constants;

namespace WpfTemplate.Views
{
    /// <summary>
    /// Shell.xaml の相互作用ロジック
    /// </summary>
    public partial class Shell : MetroWindow
    {
        public Shell(IRegionManager regionManager)
        {
            InitializeComponent();
            // The RegionManager.RegionName attached property XAML-Declaration doesn't work for this scenario (object declarated outside the logical tree)
            // theses objects are not part of the logical tree, hence the parent that has the region manager to use (the Window) cannot be found using LogicalTreeHelper.FindParent 
            // therefore the regionManager is never found and cannot be assigned automatically by Prism.  This means we have to handle this ourselves
            if (regionManager != null) { 
                SetRegionManager(regionManager, this.rightWindowCommandsRegion, RegionNames.RightWindowCommandsRegion);
                SetRegionManager(regionManager, this.flyoutsControlRegion, RegionNames.FlyoutRegion);
            }
        }

        private void SetRegionManager(IRegionManager regionManager, DependencyObject regionTarget, string regionName)
        {
            RegionManager.SetRegionName(regionTarget, regionName);
            RegionManager.SetRegionManager(regionTarget, regionManager);
        }
    }
}
