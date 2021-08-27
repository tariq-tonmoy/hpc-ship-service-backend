using Microsoft.EntityFrameworkCore;
using ShipService.Infrastructure.Ship.Cqrs.Repository.Sqlite;
using ShipService.ReadSilde.ShipQueryHost.Abstractions;
using ShipService.ReadSilde.ShipQueryHost.QueryModels;
using ShipService.ReadSilde.ViewModels;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ShipService.ReadSilde.ShipQueryHost.Service.Imps
{
    public class ShipQueryRepository : IShipQueryRepository
    {
        private readonly ShipViewModelDbContext dbContext;

        public ShipQueryRepository(ShipViewModelDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbContext.Database.Migrate();
        }

        private static QueryResponsePayload GetQueryResponseStructure(ShipViewModel viewModel)
        {
            return new QueryResponsePayload()
            {
                Code = viewModel.Code,
                CreatedBy = viewModel.CreatedBy,
                CreatedDate = viewModel.CreatedDate,
                Dimensions = viewModel.DimensionViewModels.Select(y =>
                new DimensionDto
                {
                    DimensionId = y.DimensionId,
                    Height = y.Height,
                    Unit = y.Unit,
                    Width = y.Width,
                }),
                LastUpdatedBy = viewModel.LastUpdatedBy,
                LastUpdatedDate = viewModel.LastUpdatedDate,
                ShipId = viewModel.ShipId,
                ShipName = viewModel.ShipName,
            };
        }

        private static Expression<Func<ShipViewModel, QueryResponsePayload>> GetProjection()
        {
            return x => GetQueryResponseStructure(x);
        }

        public QueryResponse GetShip(Guid shipId)
        {
            QueryResponse response = new QueryResponse()
            {
                ResponsePayloads = new List<QueryResponsePayload>(),
            };

            var result = dbContext.Set<ShipViewModel>()
                                   .Include(x => x.DimensionViewModels)
                                   .FirstOrDefault(x => x.ShipId == shipId);

            var queryResponse = GetQueryResponseStructure(result);
            response.ResponsePayloads = response.ResponsePayloads.Append(queryResponse);

            return response;
        }



        public QueryResponse GetShips(ShipQueryModel query)
        {
            QueryResponse result = new QueryResponse();
            if (query.CountRequirement == CountRequirement.WithCount || query.CountRequirement == CountRequirement.WithoutCount)
            {
                var payloads = this.dbContext.Set<ShipViewModel>()
                                    .Include(x => x.DimensionViewModels)
                                    .OrderBy(x => x.Code)
                                    .Skip(query.PageIndex * query.PageSize)
                                    .Take(query.PageSize)
                                    .Select(GetProjection());
                result.ResponsePayloads = payloads;
            }
            if (query.CountRequirement == CountRequirement.WithCount || query.CountRequirement == CountRequirement.CountOnly)
            {
                result.Count = this.dbContext.Set<ShipViewModel>().Count();
            }

            return result;
        }
    }
}
