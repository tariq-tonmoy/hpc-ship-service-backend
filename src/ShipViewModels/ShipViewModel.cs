using ShipService.Infrastructure.Core;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.ReadSilde.ViewModels
{
    public class ShipViewModel : ViewModelBase
    {
        private List<DimensionViewModel> dimensionViewModels;
        public ShipViewModel(
            Guid id,
            int version,
            Guid createdBy,
            Guid lastUpdatedBy,
            DateTime createdDate,
            DateTime lastUpdatedDate,
            bool isMarkedToDelete,
            Guid shipId,
            string shipName,
            string code)
        {
            this.Id = id;
            this.Version = version;
            this.CreatedBy = createdBy;
            this.LastUpdatedBy = lastUpdatedBy;
            this.CreatedDate = createdDate;
            this.LastUpdatedDate = lastUpdatedDate;
            this.IsMarkedToDelete = isMarkedToDelete;
            this.ShipId = shipId;
            this.ShipName = shipName;
            this.Code = code;
            this.dimensionViewModels = new List<DimensionViewModel>();
        }

        public Guid ShipId { get; protected set; }

        public string ShipName { get; protected set; }

        public string Code { get; protected set; }


        public IReadOnlyCollection<DimensionViewModel> DimensionViewModels => dimensionViewModels;

        public void AddDimension(DimensionDto dimensionDto)
        {
            var dimension = new DimensionViewModel(dimensionDto.DimensionId, dimensionDto.Height, dimensionDto.Width, dimensionDto.Unit);
            this.dimensionViewModels.Add(dimension);
        }
    }
}
