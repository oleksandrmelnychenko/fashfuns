using Android.App;
using Android.Content;
using FashFans.Droid.PayPal;
using FashFans.Droid.PayPal.PayPalNative;
using FashFans.Models.Args.PayPal;
using FashFans.Models.PayPal;
using FashFans.Services.Platform;
using FashFans.Services.Platform.Contracts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.PayPal.Android;

[assembly: Dependency(typeof(PlatformPayPalService))]
namespace FashFans.Droid.PayPal.PayPalNative {
    public class PlatformPayPalService : IPayPalNative {

        private PayPalManager _payPalManager;

        public PlatformPayPalService() {
            _payPalManager = MainActivity._payPalManager;
        }

        public void Buy(decimal amount) {
            _payPalManager.BuySomething();
        }

        public void BuyMany(object things) {
            
        }
    }
}