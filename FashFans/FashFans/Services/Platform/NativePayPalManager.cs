using FashFans.Services.Platform.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace FashFans.Services.Platform {
    public class NativePayPalManager : IPayPalNative {
        public void Buy(decimal amount) {
            DependencyService.Get<IPayPalNative>().Buy(amount);
        }

        public void BuyMany(object things) {
            DependencyService.Get<IPayPalNative>().BuyMany(things);
        }
    }
}
