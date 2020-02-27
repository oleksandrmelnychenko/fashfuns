using Android.App;
using Android.Content;
using Android.Widget;
using Java.Math;
using Org.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.PayPal.Android;

namespace FashFans.Droid.PayPal.PayPalNative {
    public class PayPalManager {

        private Context _context;

        public PayPalConfiguration _payPalConfiguration;

        private const string CLIENT_ID = "Act90tyvdDzV-XMi4zfxlIx-eEdRCA1eagJta0aLhFJQdh9TZ4WU8tfLyCL_ajNfjbZiN4cvjPwXpjym";

        private static string CONFIG_ENVIRONMENT = PayPalConfiguration.EnvironmentSandbox;

        public static int REQUEST_CODE_PAYMENT = 1;

        public static int REQUEST_CODE_FUTURE_PAYMENT = 2;

        public static int REQUEST_CODE_PROFILE_SHARING = 3;

        /// <summary>
        ///     ctor().
        /// </summary>
        /// <param name="context"></param>
        public PayPalManager(Context context) {
            _context = context;

            _payPalConfiguration = new PayPalConfiguration()
                .Environment(CONFIG_ENVIRONMENT)
                .ClientId(CLIENT_ID)
                .MerchantName("Fash Fans shop")
                .MerchantPrivacyPolicyUri(Android.Net.Uri.Parse("https://www.example.com/privacy"))
                .MerchantUserAgreementUri(Android.Net.Uri.Parse("https://www.example.com/legal"));

            Intent intent = new Intent(_context, typeof(PayPalService));
            intent.PutExtra(PayPalService.ExtraPaypalConfiguration, _payPalConfiguration);
            _context.StartService(intent);
        }

        public void BuySomething() {
            /*
             * PAYMENT_INTENT_SALE will cause the payment to complete immediately.
             * Change PAYMENT_INTENT_SALE to 
             *   - PAYMENT_INTENT_AUTHORIZE to only authorize payment and capture funds later.
             *   - PAYMENT_INTENT_ORDER to create a payment for authorization and capture
             *     later via calls from your server.
             * 
             * Also, to include additional payment details and an item list, see getStuffToBuy() below.
             */
            PayPalPayment thingToBuy = GetThingToBuy("12.55", "USD", PayPalPayment.PaymentIntentSale);
            PayPalPayment things = GetStuffToBuy(PayPalPayment.PaymentIntentSale);

            Intent intent = new Intent(_context, typeof(PaymentActivity));
            intent.PutExtra(PayPalService.ExtraPaypalConfiguration, _payPalConfiguration);
            intent.PutExtra(PaymentActivity.ExtraPayment, things);

            (_context as Activity).StartActivityForResult(intent, REQUEST_CODE_PAYMENT);
        }

        private PayPalPayment GetThingToBuy(string amount, string currency, string paymentIntent) {
            return new PayPalPayment(new Java.Math.BigDecimal(amount), currency, "Best T-Shirt", paymentIntent);
        }

        private PayPalPayment GetStuffToBuy(string paymentIntent) {
            PayPalItem[] items = {
                new PayPalItem("sample item #1", new Java.Lang.Integer(2), new Java.Math.BigDecimal("87.50"), "USD",
                    "sku-12345678"),
                new PayPalItem("free sample item #2", new Java.Lang.Integer(1), new Java.Math.BigDecimal("0.00"),
                    "USD", "sku-zero-price"),
                new PayPalItem("sample item #3 with a longer name", new Java.Lang.Integer(6), new Java.Math.BigDecimal("37.99"),
                    "USD", "sku-33333")
            };

            BigDecimal subtotal = PayPalItem.GetItemTotal(items);
            BigDecimal shipping = new BigDecimal("7.31");
            BigDecimal tax = new BigDecimal("4.67");
            PayPalPaymentDetails payPalPaymentDetails = new PayPalPaymentDetails(shipping, subtotal, tax);

            BigDecimal amount = subtotal.Add(shipping).Add(tax);

            PayPalPayment payPalPayment = new PayPalPayment(amount, "USD", "sample item", paymentIntent);
            payPalPayment.Items(items).PaymentDetails(payPalPaymentDetails);

            payPalPayment.Custom("This is text that will be associated with the payment that the app can use.");

            return payPalPayment;
        }

        private void AddAppProvidedShippingAddress(PayPalPayment payPalPayment) {
            ShippingAddress shippingAddress = new ShippingAddress().RecipientName("Mom Parker")
                .Line1("52 North Main St.")
                .City("Austin")
                .State("TX")
                .PostalCode("78729")
                .CountryCode("US");
            payPalPayment.InvokeProvidedShippingAddress(shippingAddress);
        }

        private void EnableShippingAddressRetrieval(PayPalPayment payPalPayment, bool enable) {
            payPalPayment.EnablePayPalShippingAddressesRetrieval(enable);
        }

        private PayPalOAuthScopes GetOAuthScopes() {
            HashSet<string> scopes = new HashSet<string>();
            scopes.Add(PayPalOAuthScopes.PaypalScopeEmail);
            scopes.Add(PayPalOAuthScopes.PaypalScopeAddress);
            return new PayPalOAuthScopes(scopes.ToList());
        }

        private void SendAuthorizationToServer(PayPalAuthorization payPalAuthorization) {
            // To Do Send the authorization response to your server, where it can
            // exchange the authorization code for OAuth access and refresh tokens.
        }
       
        public void FuturePaymentPurchase() {
            string metadataId = PayPalConfiguration.GetClientMetadataId(_context);
            System.Diagnostics.Debug.WriteLine("Client Metadata ID: " + metadataId);

            // TODO: Send metadataId and transaction details to your server for processing with
            // PayPal...
            Toast.MakeText(
                _context.ApplicationContext, "Client Metadata Id received from SDK", ToastLength.Long)
                .Show();
        }

        public void FuturePayment() {
            Intent intent = new Intent(_context, typeof(PayPalFuturePaymentActivity));

            // send the same configuration for restart resiliency
            intent.PutExtra(PayPalService.ExtraPaypalConfiguration, _payPalConfiguration);

            (_context as Activity).StartActivityForResult(intent, REQUEST_CODE_FUTURE_PAYMENT);
        }

        public void ProfileSharing() {
            Intent intent = new Intent(_context, typeof(PayPalProfileSharingActivity));

            // send the same configuration for restart resiliency
            intent.PutExtra(PayPalService.ExtraPaypalConfiguration, _payPalConfiguration);

            intent.PutExtra(PayPalProfileSharingActivity.ExtraRequestedScopes, GetOAuthScopes());

            (_context as Activity).StartActivityForResult(intent, REQUEST_CODE_PROFILE_SHARING);
        }

        public void Destroy() {
            _context.StopService(new Intent(_context, typeof(PayPalService)));
        }

        public void OnActivityResult(int requestCode, Result resultCode, Android.Content.Intent data) {
            if (requestCode == PayPalManager.REQUEST_CODE_PAYMENT) {
                if (resultCode == Result.Ok) {
                    PaymentConfirmation confirm =
                        (PaymentConfirmation)data.GetParcelableExtra(PaymentActivity.ExtraResultConfirmation);
                    if (confirm != null) {
                        try {
                            System.Diagnostics.Debug.WriteLine(confirm.ToJSONObject().ToString(4));
                            System.Diagnostics.Debug.WriteLine(confirm.Payment.ToJSONObject().ToString(4));
                            /**
                            *  TODO: send 'confirm' (and possibly confirm.getPayment() to your server for verification
                            * or consent completion.
                            * See https://developer.paypal.com/webapps/developer/docs/integration/mobile/verify-mobile-payment/
                            * for more details.
                            *
                            * For sample mobile backend interactions, see
                            * https://github.com/paypal/rest-api-sdk-python/tree/master/samples/mobile_backend
                            */
                            Toast.MakeText(
                                _context.ApplicationContext,
                                "PaymentConfirmation info received from PayPal", ToastLength.Short)
                                .Show();

                        }
                        catch (JSONException e) {
                            System.Diagnostics.Debug.WriteLine("an extremely unlikely failure occurred: " + e.Message);
                        }
                    }
                } else if (resultCode == Result.Canceled) {
                    System.Diagnostics.Debug.WriteLine("The user canceled.");
                } else if ((int)resultCode == PaymentActivity.ResultExtrasInvalid) {
                    System.Diagnostics.Debug.WriteLine(
                        "An invalid Payment or PayPalConfiguration was submitted. Please see the docs.");
                }
            } else if (requestCode == REQUEST_CODE_FUTURE_PAYMENT) {
                if (resultCode == Result.Ok) {
                    PayPalAuthorization auth = (Xamarin.PayPal.Android.PayPalAuthorization)data.GetParcelableExtra(PayPalFuturePaymentActivity.ExtraResultAuthorization);
                    if (auth != null) {
                        try {
                            System.Diagnostics.Debug.WriteLine(auth.ToJSONObject().ToString(4));

                            String authorization_code = auth.AuthorizationCode;
                            System.Diagnostics.Debug.WriteLine(authorization_code);

                            SendAuthorizationToServer(auth);
                            Toast.MakeText(
                                _context.ApplicationContext,
                                "Future Payment code received from PayPal", ToastLength.Long)
                                .Show();

                        }
                        catch (JSONException e) {
                            System.Diagnostics.Debug.WriteLine("an extremely unlikely failure occurred: " + e.Message);
                        }
                    }
                } else if (resultCode == Result.Ok) {
                    System.Diagnostics.Debug.WriteLine("The user canceled.");
                } else if ((int)resultCode == PayPalFuturePaymentActivity.ResultExtrasInvalid) {
                    System.Diagnostics.Debug.WriteLine(
                        "Probably the attempt to previously start the PayPalService had an invalid PayPalConfiguration. Please see the docs.");
                }
            } else if (requestCode == REQUEST_CODE_PROFILE_SHARING) {
                if (resultCode == Result.Ok) {
                    PayPalAuthorization auth = (Xamarin.PayPal.Android.PayPalAuthorization)data.GetParcelableExtra(PayPalProfileSharingActivity.ExtraResultAuthorization);
                    if (auth != null) {
                        try {
                            System.Diagnostics.Debug.WriteLine(auth.ToJSONObject().ToString(4));

                            String authorization_code = auth.AuthorizationCode;
                            System.Diagnostics.Debug.WriteLine(authorization_code);

                            SendAuthorizationToServer(auth);
                            Toast.MakeText(
                                _context.ApplicationContext,
                                "Profile Sharing code received from PayPal", ToastLength.Short)
                                .Show();

                        }
                        catch (JSONException e) {
                            System.Diagnostics.Debug.WriteLine("an extremely unlikely failure occurred: " + e.Message);
                        }
                    }
                } else if (resultCode == Result.Canceled) {
                    System.Diagnostics.Debug.WriteLine("The user canceled.");
                } else if ((int)resultCode == PayPalFuturePaymentActivity.ResultExtrasInvalid) {
                    System.Diagnostics.Debug.WriteLine(
                        "Probably the attempt to previously start the PayPalService had an invalid PayPalConfiguration. Please see the docs.");
                }
            }
        }

        public static implicit operator global::PayPal.Forms.PayPalManager(PayPalManager v) {
            throw new NotImplementedException();
        }
    }
}