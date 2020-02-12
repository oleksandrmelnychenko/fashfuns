﻿namespace FashFans.Models.Rest.EndPoints {
    public class ShoppingEndPoints {

        private const string SHOPPING_CART_API_KEY = "api/v1/products/get/shopping/cart/{0}";

        string _baseEndpoint;
        public string BaseEndpoint {
            get { return _baseEndpoint; }
            set {
                _baseEndpoint = value;
                UpdateEndpoint(_baseEndpoint);
            }
        }

        public string ShoppingCartInfoEndPoint { get; private set; }

      

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="defaultEndPoint"></param>
        public ShoppingEndPoints(string defaultEndPoint) {
            BaseEndpoint = defaultEndPoint;
        }

        private void UpdateEndpoint(string baseEndpoint) {
            ShoppingCartInfoEndPoint = $"{baseEndpoint}/{SHOPPING_CART_API_KEY}";
        }
    }
}
