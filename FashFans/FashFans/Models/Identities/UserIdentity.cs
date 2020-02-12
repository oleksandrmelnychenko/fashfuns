using System;
using System.Collections.Generic;
using System.Text;

namespace FashFans.Models.Identities {
    public class UserIdentity : EntityBase {

        public UserIdentity() {
            UserRoles = new HashSet<UserRole>();
        }

        public string Email { get; set; }

        public string Name { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }

        public bool IsPasswordExpired { get; set; } = false;

        public bool CanUserResetExpiredPassword { get; set; } = true;

        public DateTime PasswordExpiresAt { get; set; } = DateTime.UtcNow.AddYears(1);

        public long? PasswordExpiresAtTicks {
            get {
                if (PasswordExpiresAt != null) {
                    return PasswordExpiresAt.Ticks;
                }
                return null;
            }
        }

        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
