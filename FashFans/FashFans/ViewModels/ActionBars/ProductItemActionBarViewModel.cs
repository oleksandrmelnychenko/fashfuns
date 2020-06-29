using FashFans.Models.Identities;
using FashFans.ViewModels.Base;
using FashFans.ViewModels.MainContent;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.ActionBars {
    public sealed class ProductItemActionBarViewModel : ActionBarBaseViewModel {

        bool _isBackButtonAvailable;
        public bool IsBackButtonAvailable {
            get { return _isBackButtonAvailable; }
            private set { SetProperty(ref _isBackButtonAvailable, value); }
        }

        long _productCount;
        public long ProductCount {
            get { return _productCount; }
            set { SetProperty(ref _productCount, value); }
        }

        public ICommand OpenCardCommand => new Command(async () => await NavigationService.NavigateToModalAsync<CartViewModel>(null));

        /// <summary>
        ///     ctor().
        /// </summary>
        public ProductItemActionBarViewModel() {

        }

        public override Task InitializeAsync(object navigationData) {

            if(navigationData is ShoppingCartInfo shoppingCartInfo) {
                ProductCount = shoppingCartInfo.ProductCount;
            }

            IsBackButtonAvailable = NavigationService.IsBackButtonAvailable;

            return base.InitializeAsync(navigationData);
        }
    }
}
