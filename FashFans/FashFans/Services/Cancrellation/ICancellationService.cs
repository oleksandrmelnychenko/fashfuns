using System.Threading;

namespace FashFans.Services.Cancrellation {
    public interface ICancellationService {
        CancellationTokenSource GetCancellationTokenSource();

        CancellationToken GetToken();

        void Cancel();
    }
}
