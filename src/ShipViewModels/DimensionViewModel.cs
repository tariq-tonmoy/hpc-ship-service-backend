using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ViewModels
{
    public class DimensionViewModel
    {
        public DimensionViewModel(
            Guid dimensionId,
            decimal height,
            decimal width,
            string unit)
        {
            this.DimensionId = dimensionId;
            this.Height = height;
            this.Width = width;
            this.Unit = unit;
        }

        public Guid ViewModelId { get; protected set; }

        public Guid DimensionId { get; protected set; }

        public decimal Height { get; protected set; }

        public decimal Width { get; protected set; }

        public string Unit { get; protected set; }

        public virtual ShipViewModel ShipViewModel { get; set; }
    }
}
