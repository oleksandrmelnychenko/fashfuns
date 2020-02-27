namespace FashFans.Services.Platform.Contracts {
    public interface IPayPal {
        void Buy(decimal amount);

        void BuyMany(object things);
    }
}
