using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Shared.SharedDto
{
    public class ShipDto
    {
        public Guid ShipId { get; set; }

        public string ShipName { get; set; }

        public string Code { get; set; }

        public IEnumerable<DimensionDto> Dimensions { get; set; }
    }
}
