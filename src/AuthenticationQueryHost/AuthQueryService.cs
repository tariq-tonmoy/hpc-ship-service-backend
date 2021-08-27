using Grpc.Core;
using ShipService.External.AuthenticationQueryHost.Protos;
using ShipService.External.AuthViewModel;
using ShipService.Infrastructure.Cqrs.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static ShipService.External.AuthenticationQueryHost.Protos.AuthQuery;

namespace ShipService.External.AuthenticationQueryHost
{
    public class AuthQueryService : AuthQuery.AuthQueryBase
    {
        private readonly IReadRepository<AuthenticationViewModel> readRepository;

        public AuthQueryService(IReadRepository<AuthenticationViewModel> readRepository)
        {
            this.readRepository = readRepository;
        }

        public override Task<AuthQueryResponseModel> Authenticate(AuthQueryModel query, ServerCallContext context)
        {
            var dbResponse = readRepository.GetByFilter(x => x.Username == query.Username && x.Password == query.Password).FirstOrDefault();

            AuthQueryResponseModel responseModel = new AuthQueryResponseModel();
            if (dbResponse != null)
            {
                responseModel.IsAuthenticated = true;
                responseModel.UserId = dbResponse.Id.ToString();
                responseModel.Username = dbResponse.Username;
                responseModel.Role = dbResponse.Role;
            }

            return Task.FromResult(responseModel);
        }
    }
}
