using System.Windows;
using System.Windows.Controls;

namespace CoreTools.WPF.Controls
{
    public class TreeListView : TreeView
    {
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)

        {
            return item is TreeListViewItem;
        }

        public GridViewColumnCollection Columns => _columns ??= new GridViewColumnCollection();

        private GridViewColumnCollection? _columns;
    }
}