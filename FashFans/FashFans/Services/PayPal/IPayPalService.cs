using FashFans.Models.Args.PayPal;
using FashFans.Models.PayPal;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FashFans.Services.PayPal {
    public interface IPayPalService {
        Task<PayPalTokenArgs>  GetAccessTokenAsync(CancellationToken cancellationToken = default);

        Task<WebExperienceProfile> CreateWebExperienceProfileAsync(WebProfileInfo createWebProfileInfo, CancellationToken cancellationToken = default);

        Task<WebExperienceProfile> GetWebExperienceProfileByIdAsync(string id, CancellationToken cancellationToken = default);

        Task<List<WebExperienceProfile>> GetWebExperienceProfilesAsync(CancellationToken cancellationToken = default);
    }
}
