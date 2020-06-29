using FashFans.Models.Identities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FashFans.Services.Cart {
    public interface IProductService {
        Task<ShoppingCartInfo> GetShoppingCartInfoAsync(CancellationToken cancellationToken = default(CancellationToken));

        Task<List<Product>> GetProductsAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
