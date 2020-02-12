﻿using FashFans.Views.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace FashFans.ViewModels.Base {
    public abstract class TabbedViewModelBase : NestedViewModel, IBottomBarTab {

        public TabbedViewModelBase() {
            TabbViewModelInit();
        }

        public bool IsBudgeVisible { get; protected set; }

        public int BudgeCount { get; protected set; }

        public string TabHeader { get; protected set; }

        public string TabIcon { get; protected set; }

        public string TabName { get; protected set; }

        public Type RelativeViewType { get; protected set; }

        public Type BottomTasselViewType { get; protected set; } = typeof(SingleBottomItem);

        public bool HasBackgroundItem { get; protected set; }

        protected abstract void TabbViewModelInit();
    }
}
