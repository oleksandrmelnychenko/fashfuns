using Xamarin.Essentials;

namespace FashFans.Services.OpenUrl {
    internal class OpenUrlService : IOpenUrlService {
        public async void OpenUrl(string url) {
            await Launcher.OpenAsync(url);
        }
    }
}
