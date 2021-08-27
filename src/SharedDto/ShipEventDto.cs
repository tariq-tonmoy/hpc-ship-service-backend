using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Shared.SharedDto
{
    public class ShipEventDto
    {
        public Guid ShipId { get; set; }

        public int Version { get; set; }

        public Guid CreatedBy { get; set; }

        public Guid LastUpdatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public bool IsMarkedToDelete { get; set; }

        public string ShipName { get; set; }

        public string Code { get; set; }

        public IEnumerable<DimensionDto> Dimensions { get; set; }
    }
}
