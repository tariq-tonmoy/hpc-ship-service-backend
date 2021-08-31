using ShipService.External.AuthenticationQueryHost.Abstractions;
using ShipService.External.AuthenticationQueryHost.Models;
using ShipService.External.AuthViewModel;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using System.Linq;

namespace ShipService.External.AuthenticationQueryHost.Service.Imps
{
    public class AuthenticationServiceProvider : IAuthenticationServiceProvider
    {
        private readonly IReadRepository<AuthenticationViewModel> readRepository;

        public AuthenticationServiceProvider(IReadRepository<AuthenticationViewModel> readRepository)
        {
            this.readRepository = readRepository;
        }

        public QueryResponse Authenticate(AuthQuery query)
        {
            var dbResponse = readRepository.GetByFilter(x => x.Username == query.Username && x.Password == query.Password).FirstOrDefault();

            QueryResponse response = new QueryResponse();

            if (dbResponse != null)
            {
                response.IsAuthenticated = true;
                response.UserId = dbResponse.Id;
                response.Username = dbResponse.Username;
                response.Role = dbResponse.Role;
            }

            return response;
        }
    }
}
