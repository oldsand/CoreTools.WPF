using System;
using Prism.Regions;

namespace ui.wpf.Mvvm
{
    public abstract class NavigationViewModelBase : ViewModelBase, IConfirmNavigationRequest, IRegionMemberLifetime
    //,IRegionManagerAware, ICreateScopedRegionManager
    {
        public virtual bool KeepAlive => true;

        public virtual bool CreateScopedRegionManager => false;

        public IRegionManager RegionManager { get; set; }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext) => true;

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