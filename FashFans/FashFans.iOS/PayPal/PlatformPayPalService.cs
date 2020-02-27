using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FashFans.iOS.PayPal;
using FashFans.Services.Platform;
using FashFans.Services.Platform.Contracts;
using Foundation;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformPayPalService))]
namespace FashFans.iOS.PayPal {
    public class PlatformPayPalService : IPayPalNative {

        private PayPalManager _payPalManager;

        public PlatformPayPalService() {
            _payPalManager = new PayPalManager();
        }

        public void Buy(decimal amount) {
            _payPalManager.BuySomething();
        }

        public void BuyMany(object things) {
            
        }
    }
}