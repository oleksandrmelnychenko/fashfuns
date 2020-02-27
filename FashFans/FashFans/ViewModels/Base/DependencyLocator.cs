using Autofac;
using FashFans.DataItemBuilders.NavigationItem;
using FashFans.Models.Identities;
using FashFans.Models.Rest.EndPoints;
using FashFans.Services.Cancrellation;
using FashFans.Services.Cart;
using FashFans.Services.Dialog;
using FashFans.Services.Identity;
using FashFans.Services.Media;
using FashFans.Services.Navigation;
using FashFans.Services.OpenUrl;
using FashFans.Services.PayPal;
using FashFans.Services.Platform;
using FashFans.Services.Platform.Contracts;
using FashFans.Services.RequestProvider;
using FashFans.ViewModels.ActionBars;
using FashFans.ViewModels.BottomTabs.Categories;
using FashFans.ViewModels.BottomTabs.FashFans;
using FashFans.ViewModels.BottomTabs.Home;
using FashFans.ViewModels.BottomTabs.Profile;
using FashFans.ViewModels.BottomTabs.Shop;
using FashFans.ViewModels.Items;
using FashFans.ViewModels.MainContent;
using FashFans.ViewModels.Registration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using Xamarin.Forms;

namespace FashFans.ViewModels.Base {
    public static class DependencyLocator {
        private static IContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
          BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(DependencyLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable) {
            return (bool)bindable.GetValue(AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value) {
            bindable.SetValue(AutoWireViewModelProperty, value);
        }

        public static void RegisterDependencies() {
            var builder = new ContainerBuilder();

            // Types.
            builder.RegisterType<UserProfile>();
            builder.RegisterType<RestEndpoints>();

            // ViewModels.
            builder.RegisterType<CartViewModel>();
            builder.RegisterType<MainViewModel>();
            builder.RegisterType<HomeViewModel>();
            builder.RegisterType<ShopViewModel>();
            builder.RegisterType<SignInViewModel>();
            builder.RegisterType<SignUpViewModel>();
            builder.RegisterType<WelcomeViewModel>();
            builder.RegisterType<ProfileViewModel>();
            builder.RegisterType<FashFansViewModel>();
            builder.RegisterType<CategoriesViewModel>();
            builder.RegisterType<ProductItemViewModel>();
            builder.RegisterType<CartActionBarViewModel>();
            builder.RegisterType<NavigationItemViewModel>();
            builder.RegisterType<CommonActionBarViewModel>();
            builder.RegisterType<FashFansContentViewModel>();
            builder.RegisterType<DesignersContentViewModel>();
            builder.RegisterType<ProductItemActionBarViewModel>();

            // Services.
            builder.RegisterType<CartService>().As<ICartService>();
            builder.RegisterType<PayPalService>().As<IPayPalService>();
            builder.RegisterType<DialogService>().As<IDialogService>();
            builder.RegisterType<OpenUrlService>().As<IOpenUrlService>();
            builder.RegisterType<IdentityService>().As<IIdentityService>();
            builder.RegisterType<RequestProvider>().As<IRequestProvider>().SingleInstance();
            builder.RegisterType<PickMediaService>().As<IPickMediaService>();
            builder.RegisterType<NavigationService>().As<INavigationService>().SingleInstance();
            builder.RegisterType<CancellationService>().As<ICancellationService>();

            builder.RegisterType<CommonPayPalManager>().As<IPayPal>();
            builder.RegisterType<NativePayPalManager>().As<IPayPalNative>();

            // Builders.
            builder.RegisterType<NavigationItemBuilder>().As<INavigationItemBuilder>();

            if (_container != null) {
                _container.Dispose();
            }
            _container = builder.Build();
        }

        public static T Resolve<T>() => _container.Resolve<T>();

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue) {
            if (!(bindable is Element view)) return;

            var viewType = view.GetType();
            var viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
            var viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null) {
                Debug.WriteLine("------------------------ERROR: Can't find viewModel type ---------------------");
                return;
            }

            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }
}
