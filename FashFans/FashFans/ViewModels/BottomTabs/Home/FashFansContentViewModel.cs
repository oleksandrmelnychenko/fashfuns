using FashFans.Exceptions;
using FashFans.Extensions;
using FashFans.Models.Args.SelectedContent;
using FashFans.Models.Identities;
using FashFans.Services.Cart;
using FashFans.ViewModels.Base;
using FashFans.ViewModels.MainContent;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.BottomTabs.Home {
    public sealed class FashFansContentViewModel : NestedViewModel {

        private readonly IProductService _productService;

        ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products {
            get { return _products; }
            set { SetProperty(ref _products, value); }
        }

        Product _selectedProduct;
        public Product SelectedProduct {
            get { return _selectedProduct; }
            set {
                SetProperty(ref _selectedProduct, value);
            }
        }

        public ICommand SelectedCommand => new Command((x) => {

            if (x is SelectionChangedEventArgs item) {
                if (item.CurrentSelection.FirstOrDefault() is Product product) {
                    NavigateToProductInfo(product);
                    SelectedProduct = null; // after back command cleared selection.
                }
            }
        });

        /// <summary>
        ///     ctor().
        /// </summary>
        public FashFansContentViewModel(IProductService productService) {
            _productService = productService;
            GetProducts();
        }

        public override void Dispose() {
            base.Dispose();
            ClearSource();
        }

        public override Task InitializeAsync(object navigationData) {

            if (navigationData is SelectedContentArgs) {
                ClearSource();
                GetProducts();
            }

            return base.InitializeAsync(navigationData);
        }

        private void ClearSource() {
            Products?.Clear();
            SelectedProduct = null;
        }

        private async void NavigateToProductInfo(Product product) {
            await NavigationService.NavigateToAsync<ProductItemViewModel>(product);
        }

        private async void GetProducts() {
            IsBusy = true;

            try {
                var allProducts = await _productService.GetProductsAsync();

                Products = allProducts.ToObservableCollection();
            }
            catch (HttpRequestExceptionEx ex) {
                var error = JsonConvert.DeserializeObject<HttpRequestResultException>(ex.Message);
                Debug.WriteLine($"ERROR:{error.Message}");
                Debugger.Break();
                IsBusy = false;
                await DialogService.ShowAlertAsync(error.Message, "ERROR", "OK");
            }
            catch (Exception ex) {
                IsBusy = false;
                Debug.WriteLine($"ERROR:{ex.Message}");
                Debugger.Break();
            }

            IsBusy = false;
        }
    }
}
