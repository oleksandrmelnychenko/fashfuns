using FashFans.Models.Identities;
using FashFans.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.Items {
    public sealed class NavigationItemViewModel : NestedViewModel {

        string _navigationTypeName;
        public string NavigationTypeName {
            get { return _navigationTypeName; }
            set {SetProperty(ref _navigationTypeName,value); }
        }

        string _imgSource;
        public string ImgSource {
            get { return _imgSource; }
            set { SetProperty(ref _imgSource, value); }
        }

        string _selectedImgSource;
        public string SelectedImgSource {
            get { return _selectedImgSource; }
            set { SetProperty(ref _selectedImgSource, value); }
        }

        bool _isSelectedItem;
        public bool IsSelectedItem {
            get { return _isSelectedItem; }
            set { SetProperty(ref _isSelectedItem, value); }
        }

        public NavigationType NavigationType { get; set; }

        public ICommand NavigateToTypeCommand => new Command(() => OnNavigateToType());

        /// <summary>
        ///     ctor().
        /// </summary>
        public NavigationItemViewModel() {

        }

        private void OnNavigateToType() {
            NavigateToTypeView();
        }

        public void NavigateToTypeView() {
            switch (NavigationType) {
                case NavigationType.FashFansCommunity:
                    break;
                case NavigationType.Designers:
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
    }
}
