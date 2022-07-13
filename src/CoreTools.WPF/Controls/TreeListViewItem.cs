using System.Windows;
using System.Windows.Controls;

namespace CoreTools.WPF.Controls
{
    public class TreeListViewItem : TreeViewItem

    {
        private int _level;

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new TreeListViewItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return item is TreeListViewItem;
        }
        
        public int Level 
        {
            get 
            {
                if (_level == -1) 
                {
                    _level = ItemsControlFromItemContainer(this) is TreeListViewItem parent ? parent.Level + 1 : 0;
                }

                return _level;
            }
        }
    }
}