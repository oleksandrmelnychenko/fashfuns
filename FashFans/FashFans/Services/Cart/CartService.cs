using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FashFans.Exceptions;
using FashFans.Helpers;
using FashFans.Models.Identities;
using FashFans.Services.RequestProvider;

namespace FashFans.Services.Cart {
    public class CartService : ICartService {

        private readonly IRequestProvider _requestProvider;

        /// <summary>
        ///     ctor().
        /// </summary>
        public CartService(IRequestProvider requestProvider) {
            _requestProvider = requestProvider;
        }

        public async Task<ShoppingCartInfo> GetShoppingCartInfoAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
           await Task.Run(async () => {

               ShoppingCartInfo shoppingCartInfo = null;

               string url = BaseSingleton<GlobalSetting>.Instance.RestEndpoints.ShoppingEndPoints.ShoppingCartInfoEndPoint;

               try {
                   shoppingCartInfo = await _requestProvider.GetAsync<ShoppingCartInfo>(url);
               }
               catch(ConnectivityException ex) {
                   throw ex;
               }
               catch(HttpRequestExceptionEx ex) {
                   throw ex;
               }
               catch(Exception ex) {
                   Debug.WriteLine($"ERROR:{ex.Message}");
                   Debugger.Break();
               }

               return shoppingCartInfo;
           }, cancellationToken);
    }
}
