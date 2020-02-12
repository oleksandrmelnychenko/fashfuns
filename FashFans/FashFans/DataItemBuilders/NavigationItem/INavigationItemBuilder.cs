using FashFans.DataItemBuilders.Contracts;
using FashFans.ViewModels.Items;
using System.Collections.Generic;

namespace FashFans.DataItemBuilders.NavigationItem {
    public interface INavigationItemBuilder : IItemBuilder<List<NavigationItemViewModel>> {
    }
}
