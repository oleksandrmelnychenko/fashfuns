using FashFans.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FashFans.ViewModels.ActionBars {
    public sealed class CartActionBarViewModel : ActionBarBaseViewModel {

        bool _isBackButtonAvailable;
        public bool IsBackButtonAvailable {
            get { return _isBackButtonAvailable; }
            private set { SetProperty(ref _isBackButtonAvailable, value); }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public CartActionBarViewModel() {

        }

        public override Task InitializeAsync(object navigationData) {

            IsBackButtonAvailable = NavigationService.IsBackButtonAvailable;

            return base.InitializeAsync(navigationData);
        }
    }
}
