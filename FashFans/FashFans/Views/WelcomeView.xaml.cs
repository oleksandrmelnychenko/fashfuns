using FashFans.Views.Base;
using Xamarin.Forms.Xaml;

namespace FashFans.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeView : ContentPageBaseView {
        public WelcomeView() {
            InitializeComponent();            
        }
    }
}