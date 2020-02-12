using FashFans.ViewModels.Base;
using FashFans.ViewModels.Registration;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels {
    public sealed class WelcomeViewModel : ContentPageBaseViewModel {

        public ICommand SignInCommand => new Command(async () => await NavigationService.NavigateToAsync<SignInViewModel>());

        public ICommand SignUpCommand => new Command(async () => await NavigationService.NavigateToAsync<SignUpViewModel>());

        /// <summary>
        ///     ctor().
        /// </summary>
        public WelcomeViewModel() {

        }
    }
}
