using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FashFans.iOS.PayPal.Contracts;
using Foundation;
using UIKit;
using Xamarin.PayPal.iOS;

namespace FashFans.iOS.PayPal {
    public class PayPalManager : PayPalPaymentDelegate, IPayPalProfileSharingDelegate, IFlipsideViewControllerDelegate {

        private const string ENVIROMENT_PRODUCTION = "Act90tyvdDzV-XMi4zfxlIx-eEdRCA1eagJta0aLhFJQdh9TZ4WU8tfLyCL_ajNfjbZiN4cvjPwXpjym";

        private const string ENVIROMENT_SANDBOX = "Act90tyvdDzV-XMi4zfxlIx-eEdRCA1eagJta0aLhFJQdh9TZ4WU8tfLyCL_ajNfjbZiN4cvjPwXpjym";        

        private PayPalConfiguration _payPalConfig;

        bool _acceptCreditCards;
        public bool AcceptCreditCards {
            get => _acceptCreditCards;
            set {
                _acceptCreditCards = value;
                _payPalConfig.AcceptCreditCards = _acceptCreditCards;
            }
        }

        string _environment;
        public string Environment {
            get => _environment;
            set {
                if (value != _environment) {
                    PayPalMobile.PreconnectWithEnvironment(value);
                }
                _environment = value;
            }
        }

        string _resultText;
        public string ResultText {
            get => _resultText;
            set {
                _resultText = value;
            }
        }

        /// <summary>
        ///     ctor().
        /// </summary>
        public PayPalManager() {
            PayPalMobile.InitializeWithClientIdsForEnvironments(NSDictionary.FromObjectsAndKeys(
                new NSObject[] {
                    new NSString (ENVIROMENT_PRODUCTION),
                    new NSString (ENVIROMENT_SANDBOX)                   
                }, new NSObject[] {
                    Constants.PayPalEnvironmentProduction,
                    Constants.PayPalEnvironmentSandbox                    
                }
            ));

            Environment = Constants.PayPalEnvironmentSandbox.ToString();

            _payPalConfig = new PayPalConfiguration();

            AcceptCreditCards = true;

            // Set up payPalConfig
            _payPalConfig.MerchantName = "Awesome Shirts, Inc.";
            _payPalConfig.MerchantPrivacyPolicyURL = new NSUrl("https://www.paypal.com/webapps/mpp/ua/privacy-full");
            _payPalConfig.MerchantUserAgreementURL = new NSUrl("https://www.paypal.com/webapps/mpp/ua/useragreement-full");
            _payPalConfig.LanguageOrLocale = NSLocale.PreferredLanguages[0];
            _payPalConfig.PayPalShippingAddressOption = PayPalShippingAddressOption.PayPal;

            Debug.WriteLine("PayPal iOS SDK Version: " + PayPalMobile.LibraryVersion);
        }

        public void PayPalFuturePaymentDidCancel(PayPalFuturePaymentViewController futurePaymentViewController) {
            Debug.WriteLine("PayPal Future Payment Authorization Canceled");
            ResultText = "";
            //successView.hidden = true
            futurePaymentViewController?.DismissViewController(true, null);
        }

        private void PayPalFuturePaymentViewController(PayPalFuturePaymentViewController futurePaymentViewController, NSDictionary futurePaymentAuthorization) {
            Debug.WriteLine("PayPal Future Payment Authorization Success!");
            // send authorization to your server to get refresh token.
            futurePaymentViewController?.DismissViewController(true, () => {
                ResultText = futurePaymentAuthorization.Description;
            });
        }     

        public void UserDidCancelPayPalProfileSharingViewController(PayPalProfileSharingViewController profileSharingViewController) {
            throw new NotImplementedException();
        }

        public void PayPalProfileSharingViewController(PayPalProfileSharingViewController profileSharingViewController, NSDictionary profileSharingAuthorization) {
            throw new NotImplementedException();
        }     

        public override void PayPalPaymentDidCancel(PayPalPaymentViewController paymentViewController) {
            //throw new NotImplementedException ();
            Debug.WriteLine("PayPal Payment Cancelled");
            ResultText = "";
            //successView.hidden = true
            paymentViewController?.DismissViewController(true, null);
        }

        public override void PayPalPaymentViewController(PayPalPaymentViewController paymentViewController, PayPalPayment completedPayment) {
            //throw new NotImplementedException ();
            Debug.WriteLine("PayPal Payment Success !");
            paymentViewController.DismissViewController(true, () => {
                // send completed confirmaion to your server
                Debug.WriteLine("Here is your proof of payment:" + completedPayment.Confirmation + "Send this to your server for confirmation and fulfillment.");
                ResultText = completedPayment.Description;
            });
        }

        /*public void PayPalPaymentDidCancel (PayPalPaymentViewController paymentViewController)
        {
            throw new NotImplementedException ();
        }
        public void PayPalPaymentViewController (PayPalPaymentViewController paymentViewController, PayPalPayment completedPayment)
        {
            throw new NotImplementedException ();
        }*/

        public void PreconnectWithEnvironment(string enviroment) {
            PayPalMobile.PreconnectWithEnvironment(enviroment);
        }

        public void BuySomething() {
            // Remove our last completed payment, just for demo purposes.
            ResultText = "";

            // Note: For purposes of illustration, this example shows a payment that includes
            //       both payment details (subtotal, shipping, tax) and multiple items.
            //       You would only specify these if appropriate to your situation.
            //       Otherwise, you can leave payment.items and/or payment.paymentDetails nil,
            //       and simply set payment.amount to your total charge.

            // Optional: include multiple items
            var item1 = PayPalItem.ItemWithName("Old jeans with holes", 2, new NSDecimalNumber("84.99"), "USD", "Hip-0037");
            var item2 = PayPalItem.ItemWithName("Free rainbow patch", 1, new NSDecimalNumber("0.00"), "USD", "Hip-00066");
            var item3 = PayPalItem.ItemWithName("Long-sleeve plaid shirt (mustache not included)", 1, new NSDecimalNumber("37.99"), "USD", "Hip-00291");

            var items = new PayPalItem[] {
                item1, item2, item3
            };
            var subtotal = PayPalItem.TotalPriceForItems(items);

            // Optional: include payment details
            var shipping = new NSDecimalNumber("5.99");
            var tax = new NSDecimalNumber("2.50");
            var paymentDetails = PayPalPaymentDetails.PaymentDetailsWithSubtotal(subtotal, shipping, tax);

            var total = subtotal.Add(shipping).Add(tax);

            var payment = PayPalPayment.PaymentWithAmount(total, "USD", "Hipster Clothing", PayPalPaymentIntent.Sale);

            payment.Items = items;
            payment.PaymentDetails = paymentDetails;
            if (payment.Processable) {
                var paymentViewController = new PayPalPaymentViewController(payment, _payPalConfig, this);
                var top = GetTopViewController(UIApplication.SharedApplication.KeyWindow);
                top.PresentViewController(paymentViewController, true, null);
            } else {
                // This particular payment will always be processable. If, for
                // example, the amount was negative or the shortDescription was
                // empty, this payment wouldn't be processable, and you'd want
                // to handle that here.
                Debug.WriteLine("Payment not processalbe:" + payment.Items);
            }
        }

        public void FuturePayment() {
            var futurePaymentViewController = new PayPalFuturePaymentViewController(_payPalConfig, new CustomPayPalFuturePaymentDelegate(this));
            var top = GetTopViewController(UIApplication.SharedApplication.KeyWindow);
            top.PresentViewController(futurePaymentViewController, true, null);
        }

        UIViewController GetTopViewController(UIWindow window) {
            var vc = window.RootViewController;

            while (vc.PresentedViewController != null) {
                vc = vc.PresentedViewController;
            }

            return vc;
        }

        class CustomPayPalFuturePaymentDelegate : PayPalFuturePaymentDelegate {
            PayPalManager PayPalManager;

            public CustomPayPalFuturePaymentDelegate(PayPalManager manager) {
                PayPalManager = manager;
            }

            public override void PayPalFuturePaymentDidCancel(Xamarin.PayPal.iOS.PayPalFuturePaymentViewController futurePaymentViewController) {
                PayPalManager.PayPalFuturePaymentDidCancel(futurePaymentViewController);
            }

            public override void PayPalFuturePaymentViewController(Xamarin.PayPal.iOS.PayPalFuturePaymentViewController futurePaymentViewController, NSDictionary futurePaymentAuthorization) {
                PayPalManager.PayPalFuturePaymentViewController(futurePaymentViewController, futurePaymentAuthorization);
            }
        }
    }
}