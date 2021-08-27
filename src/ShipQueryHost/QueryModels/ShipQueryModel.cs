using Microsoft.AspNetCore.Mvc;

namespace ShipService.ReadSilde.ShipQueryHost.QueryModels
{
    [BindProperties(SupportsGet = true)]
    public class ShipQueryModel
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        public CountRequirement CountRequirement { get; set; }
    }
}
