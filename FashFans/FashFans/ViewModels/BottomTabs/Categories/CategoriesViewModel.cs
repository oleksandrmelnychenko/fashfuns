using FashFans.Helpers;
using FashFans.Models.Args.BottomTabSwitcher;
using FashFans.ViewModels.Base;
using FashFans.Views.BottomTabs.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FashFans.ViewModels.BottomTabs.Categories {
    public sealed class CategoriesViewModel : TabbedViewModelBase {

        /// <summary>
        ///     ctor().
        /// </summary>
        public CategoriesViewModel() {

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
            RelativeViewType = typeof(CategoriesView);
            TabIcon = IconPath.CATEGORIES;
            HasBackgroundItem = false;
            TabName = "Categories";
        }
    }
}
