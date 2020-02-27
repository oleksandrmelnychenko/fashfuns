using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Acr.UserDialogs;
using Xamarin.Forms;
using FFImageLoading.Forms.Platform;
using Xamarin.PayPal.Android;
using FashFans.Services.Platform;
using Android.Content;
using PayPal.Forms.Abstractions;
using PayPal.Forms;

namespace FashFans.Droid {
    [Activity(Label = "FashFans", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {     

        public static Context _context;

        public static PayPalManager _payPalManager;

        protected override void OnCreate(Bundle savedInstanceState) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            _context = this;
            //_payPalManager = new PayPal.PayPalNative.PayPalManager(this);

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            PayPalSetup();

            UserDialogs.Init(this);
            CachedImageRenderer.Init(false);
            CachedImageRenderer.InitImageViewHandler();

            LoadApplication(new App());
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults) {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void PayPalSetup() {
            var config = new PayPal.Forms.Abstractions.PayPalConfiguration(PayPalEnvironment.Sandbox, "Act90tyvdDzV-XMi4zfxlIx-eEdRCA1eagJta0aLhFJQdh9TZ4WU8tfLyCL_ajNfjbZiN4cvjPwXpjym") {
                //If you want to accept credit cards
                AcceptCreditCards = true,
                //Your business name
                MerchantName = "FashFans Store",
                //Your privacy policy Url
                MerchantPrivacyPolicyUri = "https://www.example.com/privacy",
                //Your user agreement Url
                MerchantUserAgreementUri = "https://www.example.com/legal",
                // OPTIONAL - ShippingAddressOption (Both, None, PayPal, Provided)
                ShippingAddressOption = ShippingAddressOption.Both,
                // OPTIONAL - Language: Default languege for PayPal Plug-In
                Language = "EN",
                // OPTIONAL - PhoneCountryCode: Default phone country code for PayPal Plug-In
                PhoneCountryCode = "380",
            };

            CrossPayPalManager.Init(config, this);
        }

        //protected override void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data) {
        //    base.OnActivityResult(requestCode, resultCode, data);
        //    _payPalManager.OnActivityResult(requestCode, resultCode, data);
        //}

        //protected override void OnDestroy() {
        //    _payPalManager.Destroy();
        //    base.OnDestroy();
        //}
    }
}