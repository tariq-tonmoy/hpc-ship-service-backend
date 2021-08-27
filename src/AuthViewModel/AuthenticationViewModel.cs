using ShipService.Infrastructure.Core;

namespace ShipService.External.AuthViewModel
{
    public class AuthenticationViewModel : ViewModelBase
    {
        public string Username { get; protected set; }

        public string Password { get; protected set; }

        public string Role { get; protected set; }
    }
}
