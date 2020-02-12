using FashFans.Helpers;
using FashFans.Models.Args.BottomTab;
using FashFans.ViewModels.ActionBars;
using FashFans.ViewModels.Base;
using FashFans.ViewModels.BottomTabs.Categories;
using FashFans.ViewModels.BottomTabs.FashFans;
using FashFans.ViewModels.BottomTabs.Home;
using FashFans.ViewModels.BottomTabs.Profile;
using FashFans.ViewModels.BottomTabs.Shop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FashFans.ViewModels {
    public sealed class MainViewModel : ContentPageBaseViewModel {
                          
        /// <summary>
        ///     ctor().
        /// </summary>
        public MainViewModel() {
            ActionBarViewModel = DependencyLocator.Resolve<CommonActionBarViewModel>();
            ((CommonActionBarViewModel)ActionBarViewModel).InitializeAsync(this);

            List<IBottomBarTab> bottomBarTabs = new List<IBottomBarTab>() {
                DependencyLocator.Resolve<HomeViewModel>(),
                DependencyLocator.Resolve<ShopViewModel>(),
                DependencyLocator.Resolve<FashFansViewModel>(),
                DependencyLocator.Resolve<CategoriesViewModel>(),
                DependencyLocator.Resolve<ProfileViewModel>()
            };

            BottomBarItems = bottomBarTabs;
            BottomBarItems.ForEach(bottomBarTab => bottomBarTab.InitializeAsync(this));         

            SelectedBottomItemIndex = 0;
        }

        public override void Dispose() {
            base.Dispose();

            BottomBarItems?.ForEach(bottomBarItem => bottomBarItem?.Dispose());
        }

        public override Task InitializeAsync(object navigationData) {

            if (navigationData is BottomTabIndexArgs bottomTabIndexArgs) {
                try {
                    SelectedBottomItemIndex =
                        BottomBarItems.IndexOf(BottomBarItems?.FirstOrDefault(barItem => barItem.GetType().Equals(bottomTabIndexArgs.TargetTab)));
                }
                catch (Exception ex) {
                    Debug.WriteLine($"ERRROR:{ex.Message}");
                    Debugger.Break();
                }
            }

            BottomBarItems?.ForEach(bottomBarItem => bottomBarItem.InitializeAsync(navigationData));

            return base.InitializeAsync(navigationData);
        }

        protected override void OnSubscribeOnAppEvents() {
            base.OnSubscribeOnAppEvents();

        }

        protected override void OnUnsubscribeFromAppEvents() {
            base.OnUnsubscribeFromAppEvents();
            
        }       
    }
}
