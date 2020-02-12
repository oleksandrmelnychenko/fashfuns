using FashFans.Models.Identities;
using FashFans.Services.Cart;
using FashFans.ViewModels.ActionBars;
using FashFans.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.MainContent {
    public sealed class CartViewModel : ContentPageBaseViewModel {

        private readonly ICartService _cartService;

        ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        public ICommand SelectedCommand => new Command((x) => {
            if(x is SelectionChangedEventArgs item) {
                if(item.CurrentSelection.FirstOrDefault() is Product product) {
                    
                }
            }
        });

        /// <summary>
        ///     ctor().
        /// </summary>
        public CartViewModel(ICartService cartService) {
            ActionBarViewModel = DependencyLocator.Resolve<CartActionBarViewModel>();
            ((CartActionBarViewModel)ActionBarViewModel).InitializeAsync(this);

            _cartService = cartService;
        }

        public override Task InitializeAsync(object navigationData) {

            GetCart();

            return base.InitializeAsync(navigationData);
        }

        private async void GetCart() {
            var shoppingCartInfo = await _cartService.GetShoppingCartInfoAsync();
            if(shoppingCartInfo != null) {
                
            }
        }
    }
}
