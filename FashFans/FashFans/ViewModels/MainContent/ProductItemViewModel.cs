using FashFans.Models.Identities;
using FashFans.Services.Cart;
using FashFans.ViewModels.ActionBars;
using FashFans.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.MainContent {
    public sealed class ProductItemViewModel : ContentPageBaseViewModel {

        private readonly ICartService _cartService;

        Product _product;
        public Product Product {
            get { return _product; }
            set { SetProperty(ref _product, value); }
        }

        int _likeCount = 16;
        public int LikeCount {
            get { return _likeCount; }
            set { SetProperty(ref _likeCount, value); }
        }

        ObservableCollection<ITemp> _temps;
        public ObservableCollection<ITemp> Temps {
            get { return _temps; }
            set { SetProperty(ref _temps, value); }
        }

        ObservableCollection<Temp2> _secondTemps;
        public ObservableCollection<Temp2> SecondTemps {
            get { return _secondTemps; }
            set { SetProperty(ref _secondTemps, value); }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ProductItemViewModel(ICartService cartService) {
            ActionBarViewModel = DependencyLocator.Resolve<ProductItemActionBarViewModel>();
            ((ProductItemActionBarViewModel)ActionBarViewModel).InitializeAsync(this);

            _cartService = cartService;

            GetTemps();
            GetSecondTemps();
        }



        public override void Dispose() {
            base.Dispose();
        }

        public override Task InitializeAsync(object navigationData) {

            if(navigationData is Product product) {
                Product = product;
            }

            GetCart();

            return base.InitializeAsync(navigationData);
        }

        private async void GetCart() {
            var shoppingCartInfo = await _cartService.GetShoppingCartInfoAsync();
            if(shoppingCartInfo != null) {
                await ((ProductItemActionBarViewModel)ActionBarViewModel).InitializeAsync(shoppingCartInfo);
            }
        }

        private void GetTemps() {
            Temps = new ObservableCollection<ITemp> {
                new Temp {
                    ImgUrl = "resource://FashFans.Resources.Images.im_armani.png"
                },
                new Temp {
                    ImgUrl = "resource://FashFans.Resources.Images.im_armani.png"
                },
                new Temp {
                    ImgUrl = "resource://FashFans.Resources.Images.im_armani.png"
                },
                new Temp {
                    ImgUrl = "resource://FashFans.Resources.Images.im_armani.png"
                },
                new Temp {
                    ImgUrl = "resource://FashFans.Resources.Images.im_armani.png"
                },
                new Temp {
                    ImgUrl = "resource://FashFans.Resources.Images.im_armani.png"
                }
            };
        }

        private void GetSecondTemps() {
            SecondTemps = new ObservableCollection<Temp2> {
                new Temp2 {
                    ImgUrl = "resource://FashFans.Resources.Images.im_path.png",
                    ItemOperationName = "Create Outfit with this item"
                },
                 new Temp2 {
                    ImgUrl = "resource://FashFans.Resources.Images.im_standing-woman.png",
                    ItemOperationName = "Test the item on you"
                },
                  new Temp2 {
                    ImgUrl = "resource://FashFans.Resources.Images.im_measure-big.png",
                    ItemOperationName = "Select size"
                },
                   new Temp2 {
                    ImgUrl = "resource://FashFans.Resources.Images.im_palette.png",
                    ItemOperationName = "Select color"
                },
                    new Temp2 {
                    ImgUrl = "resource://FashFans.Resources.Images.im_documeeting_stroke.png",
                    ItemOperationName = "Return & Shipping policy"
                }
            };
        }
    }

    public class Temp2 {
        public string ItemOperationName { get; set; }

        public string ImgUrl { get; set; }
    }

    internal class Temp : ITemp {
        public string ImgUrl { get; set; }
    }

    public interface ITemp {
        string ImgUrl { get; set; }
    }
}
