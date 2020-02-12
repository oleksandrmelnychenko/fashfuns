using System;

namespace FashFans.ViewModels.Base {
    public interface IBottomBarTab : IVisualFiguring {

        bool HasBackgroundItem { get; }

        bool IsBudgeVisible { get; }

        int BudgeCount { get; }

        string TabIcon { get; }
        
        string TabName { get; }

        Type BottomTasselViewType { get; }
    }
}
