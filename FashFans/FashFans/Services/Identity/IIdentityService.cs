using FashFans.Models.Args.Authentication;
using FashFans.Models.Identities;
using System.Threading;
using System.Threading.Tasks;

namespace FashFans.Services.Identity {
    public interface IIdentityService {
        Task<bool> SignUpAsync(SignUpArgs signUpArgs, CancellationToken cancellationToken = default(CancellationToken));

        Task<bool> SignInAsync(SignInArgs signInArgs, CancellationToken cancellationToken = default(CancellationToken));

        Task LogOutAsync();
    }
}
