using FashFans.Views.Base;
using System;
using System.Diagnostics;
using Xamarin.Forms.Xaml;

namespace FashFans.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WelcomeView : ContentPageBaseView {
        public WelcomeView() {
            try {
                InitializeComponent();
            }
            catch (System.Exception ex) {
                Debug.WriteLine($"{ex.Message}");
            }
        }
    }
}