﻿using FashFans.Models.Args.SelectedContent;
using FashFans.Models.Identities;
using FashFans.ViewModels.Base;
using FashFans.ViewModels.MainContent;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.BottomTabs.Home {
    public sealed class FashFansContentViewModel : NestedViewModel {

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
        public FashFansContentViewModel() {
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

        private void GetProducts() {
            Products = new ObservableCollection<Product> {
                new Product {
                    ImgSource = "resource://FashFans.Resources.Images.im_skeleton_hand.png",
                    CategoryType = "Heand Bag",
                    DesignerName = "Louis Vuitton",
                    Price = "899",
                    Rate = 2,
                    Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat… ",
                    Id = 1
                },
                 new Product {
                    ImgSource = "resource://FashFans.Resources.Images.im_yellow_scirt.png",
                    CategoryType = "Yellow scirt",
                    DesignerName = "Louis Vuitton",
                    Price = "899",
                    Rate = 4,
                    Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat… ",
                    Id = 2
                },
                  new Product {
                    ImgSource = "resource://FashFans.Resources.Images.im_white_shirt.png",
                    CategoryType = "White scirt",
                    DesignerName = "Louis Vuitton",
                    Price = "899",
                    Rate = 1,
                    Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat… ",
                    Id = 3
                },
                   new Product {
                    ImgSource = "resource://FashFans.Resources.Images.im_smile.png",
                    CategoryType = "Bag",
                    DesignerName = "Louis Vuitton",
                    Price = "899",
                    Rate = 3,
                    Description = "Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat… ",
                    Id = 4
                },
            };
        }
    }
}
