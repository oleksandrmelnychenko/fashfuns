using FashFans.Helpers;
using FashFans.Models.Identities;
using FashFans.Models.Rest.EndPoints;
using FashFans.ViewModels.Base;
using Newtonsoft.Json;

namespace FashFans {
    public sealed class GlobalSetting {

        public UserProfile UserProfile { get; private set; }

        public RestEndpoints RestEndpoints { get; private set; } = DependencyLocator.Resolve<RestEndpoints>();

        /// <summary>
        ///     ctor().
        /// </summary>
        public GlobalSetting() {
            string jsonUserProfile = Settings.UserProfile;

            UserProfile = (string.IsNullOrEmpty(jsonUserProfile)) ?
                DependencyLocator.Resolve<UserProfile>() : JsonConvert.DeserializeObject<UserProfile>(jsonUserProfile);
        }

        public void SaveState() {
            Settings.UserProfile = JsonConvert.SerializeObject(BaseSingleton<GlobalSetting>.Instance.UserProfile);
        }
    }
}
