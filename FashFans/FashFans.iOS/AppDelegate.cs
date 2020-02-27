using System;
using System.Collections.Generic;
using System.Linq;
using Acr.UserDialogs;
using FFImageLoading.Forms.Platform;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using PayPal.Forms;
using PayPal.Forms.Abstractions;
using Sharpnado.Presentation.Forms.iOS;
using UIKit;
using Xamarin.Forms;

namespace FashFans.iOS {
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
            Forms.SetFlags("CollectionView_Experimental");

            global::Xamarin.Forms.Forms.Init();
            PayPalSetup();

            CachedImageRenderer.Init();
            CachedImageRenderer.InitImageSourceHandler();
            SharpnadoInitializer.Initialize();
            ImageCircleRenderer.Init();

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        private static void PayPalSetup() {
            var config = new PayPalConfiguration(PayPalEnvironment.Sandbox, "Act90tyvdDzV-XMi4zfxlIx-eEdRCA1eagJta0aLhFJQdh9TZ4WU8tfLyCL_ajNfjbZiN4cvjPwXpjym") {
                //If you want to accept credit cards
                AcceptCreditCards = true,
                StoreUserData = false,
                //Your business name
                MerchantName = "FashFans Store",
                //Your privacy policy Url
                MerchantPrivacyPolicyUri = "https://www.example.com/privacy",
                //Your user agreement Url
                MerchantUserAgreementUri = "https://www.example.com/legal",
                // OPTIONAL - ShippingAddressOption (Both, None, PayPal, Provided)
                ShippingAddressOption = ShippingAddressOption.Both,
                // OPTIONAL - Language: Default languege for PayPal Plug-In
                Language = "en",
                // OPTIONAL - PhoneCountryCode: Default phone country code for PayPal Plug-In
                PhoneCountryCode = "380"
            };

            CrossPayPalManager.Init(config);
        }
    }
}
