using Grpc.Core;
using ShipService.External.AuthenticationQueryHost.Abstractions;
using ShipService.External.AuthenticationQueryHost.Protos;
using System.Threading.Tasks;

namespace ShipService.External.AuthenticationQueryHost
{
    public class AuthQueryService : AuthQuery.AuthQueryBase
    {
        private readonly IAuthenticationServiceProvider authService;

        public AuthQueryService(IAuthenticationServiceProvider authService)
        {
            this.authService = authService;
        }

        public override Task<AuthQueryResponseModel> Authenticate(AuthQueryModel query, ServerCallContext context)
        {
            var response = this.authService.Authenticate(new Models.AuthQuery()
            {
                Username = query.Username,
                Password = query.Password,
            });

            AuthQueryResponseModel responseModel = new AuthQueryResponseModel();
            if (response != null)
            {
                responseModel.IsAuthenticated = response.IsAuthenticated;
                responseModel.UserId = response.UserId.ToString();
                responseModel.Username = response.Username;
                responseModel.Role = response.Role;
            }

            return Task.FromResult(responseModel);
        }
    }
}
