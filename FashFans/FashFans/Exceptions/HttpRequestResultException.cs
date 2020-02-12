using FashFans.Models.Identities;

namespace FashFans.Exceptions {
    public class HttpRequestResultException : BaseResponse<object> {
        public override object Data {
            get; set;
        }
    }
}
