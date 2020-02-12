using System;

namespace FashFans.Exceptions {
    internal class ConnectivityException : Exception {
        public ConnectivityException(string error) : base(error) {
        }
    }
}
