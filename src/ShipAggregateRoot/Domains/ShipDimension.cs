using ShipService.Infrastructure.Core;
using ShipService.Shared.SharedDto;
using System;

namespace ShipService.Domain.ShipAggregateRoot.Domains
{
    public class ShipDimension : IDomainBase
    {
        private decimal _height;
        private decimal _width;

        public Guid DomainId { get; protected set; }

        public Guid DimensionId { get; protected set; }

        public decimal Height
        {
            get
            {
                return _height;
            }
            protected set
            {
                this._height = (decimal)Math.Round(value, 6);
            }
        }

        public decimal Width
        {
            get
            {
                return _width;
            }
            protected set
            {
                this._width = (decimal)Math.Round(value, 6);
            }
        }

        public string Unit { get; protected set; }

        public virtual ShipAggregateRoot ShipAggregateRoot { get; set; }

        internal static ShipDimension UpdateDimension(DimensionDto dto, ShipDimension dimension)
        {
            dimension.DimensionId = dto.DimensionId;
            dimension.Height = dto.Height;
            dimension.Width = dto.Width;
            dimension.Unit = dto.Unit;
            return dimension;
        }

        internal static ShipDimension AddDimension(DimensionDto dto)
        {
            return new ShipDimension()
            {
                DimensionId = dto.DimensionId,
                Height = dto.Height,
                Width = dto.Width,
                Unit = dto.Unit,
            };
        }
    }
}
