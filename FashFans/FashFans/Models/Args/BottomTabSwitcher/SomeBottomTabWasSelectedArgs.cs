using System;

namespace FashFans.Models.Args.BottomTabSwitcher {
    public class SomeBottomTabWasSelectedArgs {

        public SomeBottomTabWasSelectedArgs(Type selectedTabType) {
            if (selectedTabType.IsClass) { }

            SelectedTabType = selectedTabType;
        }

        public Type SelectedTabType { get; private set; }
    }
}
