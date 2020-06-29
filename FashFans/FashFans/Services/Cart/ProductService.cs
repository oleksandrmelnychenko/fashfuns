using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using FashFans.Exceptions;
using FashFans.Helpers;
using FashFans.Models.Identities;
using FashFans.Services.RequestProvider;

namespace FashFans.Services.Cart {
    public class ProductService : IProductService {

        private readonly IRequestProvider _requestProvider;

        /// <summary>
        ///     ctor().
        /// </summary>
        public ProductService(IRequestProvider requestProvider) {
            _requestProvider = requestProvider;
        }

        public async Task<ShoppingCartInfo> GetShoppingCartInfoAsync(CancellationToken cancellationToken = default(CancellationToken)) =>
           await Task.Run(async () => {

               ShoppingCartInfo shoppingCartInfo = null;

               var userId = BaseSingleton<GlobalSetting>.Instance.UserProfile.Id;

               string url = string.Format(BaseSingleton<GlobalSetting>.Instance.RestEndpoints.ShoppingEndPoints.ShoppingCartInfoEndPoint, userId);

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

        public async Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default) =>
             await Task.Run(async () => {

                 List<Product> products = null;

                 var userId = BaseSingleton<GlobalSetting>.Instance.UserProfile.Id;

                 string url = BaseSingleton<GlobalSetting>.Instance.RestEndpoints.ShoppingEndPoints.GetProductsEndPoint;

                 try {
                     products = await _requestProvider.GetAsync<List<Product>>(url);
                 }
                 catch (ConnectivityException ex) {
                     throw ex;
                 }
                 catch (HttpRequestExceptionEx ex) {
                     throw ex;
                 }
                 catch (Exception ex) {
                     Debug.WriteLine($"ERROR:{ex.Message}");
                     Debugger.Break();
                 }

                 return products;
             }, cancellationToken);

    }
}
