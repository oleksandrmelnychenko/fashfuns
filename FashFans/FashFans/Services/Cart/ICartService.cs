using FashFans.Models.Identities;
using System.Threading;
using System.Threading.Tasks;

namespace FashFans.Services.Cart {
    public interface ICartService {
        Task<ShoppingCartInfo> GetShoppingCartInfoAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
