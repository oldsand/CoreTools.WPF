﻿using System.Windows;
using System.Windows.Controls;
using CoreTools.WPF.Extensions;
using CoreTools.WPF.Mvvm;
using Microsoft.Xaml.Behaviors;
using Prism.Regions;

namespace CoreTools.WPF.Behaviors
{
    public class CloseTabAction : TriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is not RoutedEventArgs args) return;
            
            var tabItem = (args.OriginalSource as DependencyObject).FindVisualAncestor<TabItem>();

            var tabControl = tabItem.FindVisualAncestor<TabControl>();
            if (tabControl == null) return;

            var region = RegionManager.GetObservableRegion(tabControl).Value;
            if (region == null) return;

            RemoveItemFromRegion(tabItem.Content, region);
        }

        private static void RemoveItemFromRegion(object item, IRegion region)
        {
            var navigationContext = new NavigationContext(region.NavigationService, null);
            if (!CanRemove(item, navigationContext)) return;
            InvokeOnNavigatedFrom(item, navigationContext);
            region.Remove(item);
        }

        private static void InvokeOnNavigatedFrom(object item, NavigationContext navigationContext)
        {
            var navigationAwareItem = MvvmHelper.GetImplementedType<INavigationAware>(item);
            navigationAwareItem?.OnNavigatedFrom(navigationContext);
        }

        private static bool CanRemove(object item, NavigationContext navigationContext)
        {
            var canRemove = true;

            var confirmRequestItem = MvvmHelper.GetImplementedType<IConfirmNavigationRequest>(item);
            confirmRequestItem?.ConfirmNavigationRequest(navigationContext, result =>
            {
                canRemove = result;
            });

            return canRemove;
        }
    }
}