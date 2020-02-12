using FashFans.Models.Args.Lifecycles;
using FashFans.Services.Dialog;
using FashFans.Services.Navigation;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FashFans.ViewModels.Base {
    public abstract class ViewModelBase : ExtendedBindableObject {

        protected readonly IDialogService DialogService;

        protected readonly INavigationService NavigationService;

        public ICommand BackCommand { get; protected set; }

        public ICommand CloseModalCommand { get; protected set; }

        public bool IsSubscribedOnAppEvents { get; private set; }

        bool _isBusy;
        public bool IsBusy {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ViewModelBase() {
            DialogService = DependencyLocator.Resolve<IDialogService>();
            NavigationService = DependencyLocator.Resolve<INavigationService>();

            BackCommand = new Command(async () => {
                await NavigationService.PreviousPageViewModel?.InitializeAsync(null);
                await NavigationService.GoBackAsync();
            });

            CloseModalCommand = new Command(async () => {
                await NavigationService.LastPageViewModel?.InitializeAsync(null);
                await NavigationService.CloseModalAsync();
            });
        }

        public virtual Task InitializeAsync(object navigationData) {
            if(!IsSubscribedOnAppEvents) {
                OnSubscribeOnAppEvents();
            }

            if(navigationData is SleepAppArg) {
                OnUnsubscribeFromAppEvents();
            }

            return Task.FromResult(false);
        }

        public virtual void Dispose() {
            OnUnsubscribeFromAppEvents();
        }


        protected void ResetCancellationTokenSource(ref CancellationTokenSource cancellationTokenSource) {
            cancellationTokenSource.Cancel();
            cancellationTokenSource = new CancellationTokenSource();
        }

        protected virtual void OnSubscribeOnAppEvents() {
            IsSubscribedOnAppEvents = true;
        }

        protected virtual void OnUnsubscribeFromAppEvents() {
            IsSubscribedOnAppEvents = false;
        }
    }
}
