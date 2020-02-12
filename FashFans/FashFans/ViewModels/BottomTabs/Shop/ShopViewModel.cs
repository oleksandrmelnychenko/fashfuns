using FashFans.Helpers;
using FashFans.Models.Args.BottomTabSwitcher;
using FashFans.ViewModels.Base;
using FashFans.Views.BottomTabs.Shop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FashFans.ViewModels.BottomTabs.Shop {
    public sealed class ShopViewModel : TabbedViewModelBase {

        /// <summary>
        ///     ctor().
        /// </summary>
        public ShopViewModel() {

        }

        public override void Dispose() {
            base.Dispose();

        }

        public override Task InitializeAsync(object navigationData) {
            if (navigationData is SelectedBottomBarTabArgs) {

            }

            return base.InitializeAsync(navigationData);
        }

        protected override void TabbViewModelInit() {
            RelativeViewType = typeof(ShopView);
            TabIcon = IconPath.SHOP;
            HasBackgroundItem = false;
            TabName = "Shop";
        }
    }
}
