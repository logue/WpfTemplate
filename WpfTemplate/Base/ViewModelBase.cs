using CommonServiceLocator;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Unity;

namespace WpfTemplate.Base
{
    public abstract class ViewModelBase : BindableBase
    {
        public ViewModelBase()
        {
            Container = ServiceLocator.Current.GetInstance<IUnityContainer>();
            RegionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            EventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
        }

        #region Properties

        private IUnityContainer _unityContainer;

        /// <summary>
        /// The unity container
        /// </summary>
        public IUnityContainer Container
        {
            get { return _unityContainer; }
            private set { SetProperty<IUnityContainer>(ref _unityContainer, value); }
        }

        private IRegionManager _regionManager;

        /// <summary>
        /// The region manager
        /// </summary>
        public IRegionManager RegionManager
        {
            get { return _regionManager; }
            private set { SetProperty<IRegionManager>(ref _regionManager, value); }
        }

        private IEventAggregator _eventAggregator;

        /// <summary>
        /// The EventAggregator
        /// </summary>
        public IEventAggregator EventAggregator
        {
            get { return _eventAggregator; }
            private set { SetProperty<IEventAggregator>(ref _eventAggregator, value); }
        }

        #endregion Properties
    }
}