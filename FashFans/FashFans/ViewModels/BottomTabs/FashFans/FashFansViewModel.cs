using FashFans.Helpers;
using FashFans.Models.Args.BottomTabSwitcher;
using FashFans.ViewModels.Base;
using FashFans.Views.BottomTabs.FashFans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FashFans.ViewModels.BottomTabs.FashFans {
    public sealed class FashFansViewModel : TabbedViewModelBase {

        /// <summary>
        ///     ctor().
        /// </summary>
        public FashFansViewModel() {

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
            RelativeViewType = typeof(FashFansView);
            TabIcon = IconPath.FASH_FANS;
            HasBackgroundItem = false;
            TabName = "FashFans";
        }
    }
}
