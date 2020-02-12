using FashFans.Models.Args.SelectedContent;
using FashFans.Models.Identities;
using FashFans.ViewModels.Base;
using FashFans.ViewModels.Items;
using System;
using System.Diagnostics;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace FashFans.Views.BottomTabs.Home {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentView {

        private const double UNVISUAL_STATE = 700;

        private const double VISUAL_STATE = default(double);

        /// <summary>
        ///     ctor().
        /// </summary>
        public HomeView() {
            InitializeComponent();
        }

        private void _nav_collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (e.CurrentSelection.FirstOrDefault() is NavigationItemViewModel navigationItemViewModel) {
                SetContent(navigationItemViewModel.NavigationType);
            }
        }

        private void SetContent(NavigationType navigationType) {
            _mainContentSpot_Grid.Children.ForEach(c => c.TranslationX = UNVISUAL_STATE);

            switch (navigationType) {
                case NavigationType.FashFansCommunity:
                    _fashFansContentView.TranslationX = VISUAL_STATE;
                    InitBindingContext(_fashFansContentView.BindingContext);
                    break;
                case NavigationType.Designers:
                    _designersContentView.TranslationX = VISUAL_STATE;
                    InitBindingContext(_designersContentView.BindingContext);
                    break;
                case NavigationType.Models:
                    break;
                case NavigationType.Stylists:
                    break;
                case NavigationType.Shop:
                    break;
                default:
                    break;
            }
        }

        private void InitBindingContext(object bindingContext) {
            try {
                if (bindingContext is ViewModelBase viewModelBase) {
                    viewModelBase.InitializeAsync(new SelectedContentArgs());
                }
            }
            catch (Exception ex) {

                Debugger.Break();
            }
        }
    }
}