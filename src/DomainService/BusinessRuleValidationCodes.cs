using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipService.Domain.DomainService
{
    public class BusinessRuleValidationCodes
    {
        public const string ShipAlreadyCreated = nameof(ShipAlreadyCreated);
        public const string ShipDoesNotExists = nameof(ShipDoesNotExists);
        public const string ShipIsAlreadyDeactivated = nameof(ShipIsAlreadyDeactivated);
        public const string PropertyValueMissing = nameof(PropertyValueMissing);
        public const string PropertyValueNotInCorrectFormat = nameof(PropertyValueNotInCorrectFormat);
        public const string Success = nameof(Success);
    }
}
