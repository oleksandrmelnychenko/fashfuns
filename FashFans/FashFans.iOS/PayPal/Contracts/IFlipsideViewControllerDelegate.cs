namespace FashFans.iOS.PayPal.Contracts {
    public interface IFlipsideViewControllerDelegate {
        bool AcceptCreditCards { get; set; }
        string Environment { get; set; }
        string ResultText { get; set; }
    }
}