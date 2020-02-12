using FashFans.Models.Identities;
using FashFans.ViewModels.Items;
using System.Collections.Generic;

namespace FashFans.DataItemBuilders.NavigationItem {
    public class NavigationItemBuilder : INavigationItemBuilder {
        public List<NavigationItemViewModel> BuildItems() {
            return new List<NavigationItemViewModel> {
                new NavigationItemViewModel {
                    ImgSource = "resource://FashFans.Resources.Images.Items.COMMUNITY.png",
                    SelectedImgSource ="resource://FashFans.Resources.Images.Items.COMMUNITY_2.png",
                    NavigationType = NavigationType.FashFansCommunity,
                    NavigationTypeName = "FASHFANS COMMUNITY"
                },
                new NavigationItemViewModel {
                    ImgSource = "resource://FashFans.Resources.Images.Items.Designers.png",
                    SelectedImgSource ="resource://FashFans.Resources.Images.Items.Designers_2.png",
                    NavigationType = NavigationType.Designers,
                    NavigationTypeName = "DESIGNERS"
                },
                new NavigationItemViewModel {
                    ImgSource = "resource://FashFans.Resources.Images.Items.Models.png",
                    SelectedImgSource ="resource://FashFans.Resources.Images.Items.Models_2.png",
                    NavigationType = NavigationType.Models,
                    NavigationTypeName = "MODELS"
                },
                new NavigationItemViewModel {
                    ImgSource = "resource://FashFans.Resources.Images.Items.STYLISTS.png",
                    SelectedImgSource ="resource://FashFans.Resources.Images.Items.STYLISTS_2.png",
                    NavigationType = NavigationType.Stylists,
                    NavigationTypeName = "STYLISTS"
                },
                new NavigationItemViewModel {
                    ImgSource = "resource://FashFans.Resources.Images.Items.Shop.png",
                    SelectedImgSource ="resource://FashFans.Resources.Images.Items.Shop_2.png",
                    NavigationType = NavigationType.Shop,
                    NavigationTypeName = "SHOP"
                }
            };
        }
    }
}
