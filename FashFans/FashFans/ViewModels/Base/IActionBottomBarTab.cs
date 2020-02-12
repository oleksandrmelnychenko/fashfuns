using System.Windows.Input;

namespace FashFans.ViewModels.Base {
    public interface IActionBottomBarTab {
        ICommand TabActionCommand { get; }
    }
}
