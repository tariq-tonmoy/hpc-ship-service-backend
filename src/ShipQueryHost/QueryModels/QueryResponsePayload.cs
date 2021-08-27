using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ShipQueryHost.QueryModels
{
    public class QueryResponsePayload
    {
        public Guid ShipId { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid LastUpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public string ShipName { get; set; }

        public string Code { get; set; }

        public IEnumerable<DimensionDto> Dimensions { get; set; }
    }
}
