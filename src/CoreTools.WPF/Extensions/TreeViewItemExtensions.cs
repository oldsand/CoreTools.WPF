using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace CoreTools.WPF.Extensions
{
    public static class TreeViewItemExtensions
    {
        public static int GetDepth(this TreeViewItem item)
        {
            while (GetParent(item) is { } parent)
            {
                return GetDepth(parent) + 1;
            }
            
            return 0;
        }

        private static TreeViewItem? GetParent(DependencyObject item)
        {
            var parent = VisualTreeHelper.GetParent(item);
            
            while (parent is not (TreeViewItem or TreeView))
            {
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent as TreeViewItem;
        }
    }
}