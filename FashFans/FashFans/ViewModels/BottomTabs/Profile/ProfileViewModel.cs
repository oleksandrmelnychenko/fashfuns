using FashFans.Helpers;
using FashFans.Models.Args.BottomTabSwitcher;
using FashFans.Services.Identity;
using FashFans.ViewModels.Base;
using FashFans.Views.BottomTabs.Profile;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.BottomTabs.Profile {
    public sealed class ProfileViewModel : TabbedViewModelBase {

        private readonly IIdentityService _identityService;

        public ICommand LogOutCommand => new Command(async () => await _identityService.LogOutAsync());

        /// <summary>
        ///     ctor().
        /// </summary>
        public ProfileViewModel(IIdentityService identityService) {
            _identityService = identityService;
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
            RelativeViewType = typeof(ProfileView);
            TabIcon = IconPath.PROFILE;
            HasBackgroundItem = false;
            TabName = "Profile";
        }
    }
}
