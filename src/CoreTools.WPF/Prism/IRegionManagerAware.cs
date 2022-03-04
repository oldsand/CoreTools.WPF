using Prism.Regions;

namespace CoreTools.WPF.Prism
{
    public interface IRegionManagerAware
    {
        IRegionManager? RegionManager { get; set; }
    }
}
