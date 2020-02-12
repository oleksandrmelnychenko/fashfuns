namespace FashFans.Models.Identities {
    public class AuthenticationResult : BaseResponse<User> {
        public override User Data { get; set; }
    }
}