using System;
using CoreTools.WPF.Prism;
using Prism.Regions;

namespace CoreTools.WPF.Mvvm
{
    public abstract class NavigationViewModelBase : ViewModelBase, IConfirmNavigationRequest, IRegionMemberLifetime,
        IRegionManagerAware, ICreateScopedRegionManager
    {
        /// <summary>
        /// Gets the value indicating whether to keep the view and view model in memory after being navigated away from.
        /// The default value is set to 'true', which will keep the view in memory.
        /// </summary>
        public virtual bool KeepAlive => true;

        public virtual bool CreateScopedRegionManager => false;

        public IRegionManager? RegionManager { get; set; }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext,
            Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }
    }
}