using FashFans.Helpers;
using FashFans.ViewModels.Base;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace FashFans.Models.Identities {
    [DataContract]
    public sealed class UserProfile : ExtendedBindableObject {

        /// <summary>
        /// User id.
        /// </summary>
        [DataMember]
        public long Id { get; set; } 
        /// Acces token by user.
        /// </summary>
        [DataMember]
        public string AccesToken { get; set; } = string.Empty;
        /// <summary>
        /// Refresh token by user.
        /// </summary>
        [DataMember]
        public string RefreshToken { get; set; } = string.Empty;
        /// <summary>
        /// Is authentication.
        /// </summary>
        [DataMember]
        public bool IsAuth { get; set; }
        /// <summary>
        /// Email.
        /// </summary>
        [DataMember]
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Id.
        /// </summary>
        [DataMember]
        public string NetId { get; set; }      
        /// <summary>
        /// User name.
        /// </summary>
        [DataMember]
        public string UserName { get; set; }
        /// <summary>
        /// User avatar.
        /// </summary>
        [DataMember]
        public string AvatarUrl { get; set; }
        /// <summary>
        /// User status.
        /// </summary>
        [DataMember]
        public bool IsAdministrator { get; internal set; }

        /// <summary>
        /// Clear user profile.
        /// </summary>
        internal void ClearUserProfile() {
            AccesToken = string.Empty;
            RefreshToken = string.Empty;
            IsAuth = false;
            Email = string.Empty;
            NetId = string.Empty;
            UserName = string.Empty;
            AvatarUrl = string.Empty;
            Id = default(long);
            IsAdministrator = default(bool);
        }

        internal void SaveChanges() {
            Settings.UserProfile = JsonConvert.SerializeObject(this);
        }
    }
}
