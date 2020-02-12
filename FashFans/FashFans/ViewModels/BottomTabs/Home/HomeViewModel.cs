using FashFans.DataItemBuilders.NavigationItem;
using FashFans.Extensions;
using FashFans.Helpers;
using FashFans.Models.Args.BottomTabSwitcher;
using FashFans.Models.Identities;
using FashFans.Services.Identity;
using FashFans.ViewModels.Base;
using FashFans.ViewModels.Items;
using FashFans.Views.BottomTabs.Home;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FashFans.ViewModels.BottomTabs.Home {
    public sealed class HomeViewModel : TabbedViewModelBase {

        NavigationItemViewModel _selectedItem;
        public NavigationItemViewModel SelectedItem {
            get { return _selectedItem; }
            set { SetProperty(ref _selectedItem, value); }
        }

        ObservableCollection<NavigationItemViewModel> _navigationTypes;
        public ObservableCollection<NavigationItemViewModel> NavigationTypes {
            get { return _navigationTypes; }
            set { SetProperty(ref _navigationTypes, value); }
        }

        public ICommand SelectedTypeCommand => new Command((x) => {
            try {
                if (x is SelectionChangedEventArgs item) {
                    NavigationTypes?.ForEach(n => n.IsSelectedItem = false);

                    if (item.CurrentSelection.FirstOrDefault() is NavigationItemViewModel navigationItemViewModel) {
                        navigationItemViewModel.IsSelectedItem = true;
                        navigationItemViewModel.NavigateToTypeView();
                    }
                }
            }
            catch (Exception ex) {
                Debug.WriteLine($"ERROR---{ex.Message}");
                Debugger.Break();
            }
        });

        /// <summary>
        ///     ctor().
        /// </summary>
        public HomeViewModel(INavigationItemBuilder navigationItemBuilder) {
            NavigationTypes = navigationItemBuilder.BuildItems().ToObservableCollection();
            NavigationTypes.FirstOrDefault().IsSelectedItem = true;
        }

        public override void Dispose() {
            base.Dispose();
            NavigationTypes?.Clear();
        }

        public override Task InitializeAsync(object navigationData) {
            if (navigationData is SelectedBottomBarTabArgs) {

            }

            return base.InitializeAsync(navigationData);
        }

        protected override void TabbViewModelInit() {
            RelativeViewType = typeof(HomeView);
            TabIcon = IconPath.HOME;
            HasBackgroundItem = false;
            TabName = "Home";
        }     
    }
}
