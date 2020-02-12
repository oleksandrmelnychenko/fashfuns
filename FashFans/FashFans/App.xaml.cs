using FashFans.Helpers;
using FashFans.Services.Navigation;
using FashFans.ViewModels.Base;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace FashFans {
    public partial class App : Application {

        /// <summary>
        ///     ctor().
        /// </summary>
        public App() {
            InitializeComponent();

            InitApp();
        }

        private void InitApp() {
            DependencyLocator.RegisterDependencies();
        }

        private Task InitNavigation() {
            INavigationService navigationService = DependencyLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected override async void OnStart() {
            base.OnSleep();

            await InitNavigation();
        }

        protected override void OnSleep() {
            base.OnSleep();
            
            BaseSingleton<GlobalSetting>.Instance.SaveState();

            DependencyLocator.Resolve<INavigationService>().UnsubscribeAfterSleepApp();
        }

        protected override void OnResume() {
            // Handle when your app resumes
            base.OnResume();

            DependencyLocator.Resolve<INavigationService>().InitAfterResumeApp();
        }
    }
}
