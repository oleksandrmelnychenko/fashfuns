using System;
using System.Collections.Generic;
using System.Text;

namespace FashFans.Models.Identities {
    public class UserAccount {
        /// <summary>
        /// Creates a blank user response class.
        /// </summary>
        public UserAccount() {
        }

        /// <summary>
        /// Creates a user response class seeding values from the user identity data.
        /// </summary>
        /// <param name="user">The current user identity</param>
        public UserAccount(UserIdentity user) {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            IsPasswordExpired = user.IsPasswordExpired;
            PasswordExpiresAt = user.PasswordExpiresAt;
            CanUserResetExpiredPassword = user.CanUserResetExpiredPassword;
        }

        /// <summary>
        /// User email address. This address will be used for authenticating the user.
        /// </summary>
        public string Email { get; set; }

        public bool CanUserResetExpiredPassword { get; set; }

        /// <summary>
        /// User Id.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Is set TRUE if the user has administrator privileges.
        /// </summary>
       // [JsonProperty("is-administrator", NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsAdministrator { get; set; }

        /// <summary>
        /// Is TRUE if the password has expired. If the password is expired, a token will not be returned.
        /// </summary>
        //[JsonProperty("is-password-expired")]
        public bool IsPasswordExpired { get; set; }

        /// <summary>
        /// User name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The date and time that the password will expire.
        /// </summary>
        //[JsonProperty("password-expires-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? PasswordExpiresAt { get; set; }

        /// <summary>
        /// The number of Ticks representing the date and time that the password will expire.
        /// </summary>
       // [JsonProperty("password-expires-at-ticks", NullValueHandling = NullValueHandling.Ignore)]
        public string PasswordExpiresAtTicks => PasswordExpiresAt?.Ticks.ToString();

        /// <summary>
        /// JWT authorization token. Must be included in the "Authorization: Bearer" header for all authorized endpoints.
        /// </summary>
        //[JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Token { get; set; }

        /// <summary>
        /// The date and time that the JWT Token will expire.
        /// </summary>
       // [JsonProperty("token-expires-at", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? TokenExpiresAt { get; set; }

        /// <summary>
        /// The number of Ticks representing the date and time that the JWT token will expire.
        /// </summary>
        //[JsonProperty("token-expires-at-ticks", NullValueHandling = NullValueHandling.Ignore)]
        public string TokenExpiresAtTicks => TokenExpiresAt?.Ticks.ToString();
    }
}
