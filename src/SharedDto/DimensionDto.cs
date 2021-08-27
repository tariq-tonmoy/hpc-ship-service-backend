using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Shared.SharedDto
{
    public class DimensionDto
    {
        public Guid DimensionId { get; set; }

        public decimal Height { get; set; }

        public decimal Width { get; set; }

        public string Unit { get; set; }
    }
}
