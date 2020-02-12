using FashFans.Views.Base;
using Xamarin.Forms.Xaml;

namespace FashFans.Views.MainContent {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartView : ContentPageBaseView {
        public CartView() {
            InitializeComponent();
        }
    }
}