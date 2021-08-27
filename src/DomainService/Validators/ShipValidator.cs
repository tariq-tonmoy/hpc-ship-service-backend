using FluentValidation;
using ShipService.Domain.ShipEvents.EventMessages;
using ShipService.Infrastructure.Core;
using ShipService.Infrastructure.Core.UserContextProvider;
using ShipService.Shared.SharedDto;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShipService.Domain.DomainService.Validators
{
    public class ShipValidator : AbstractValidator<ShipDto>
    {
        private const char seperationChar = '-';
        private const char latinFirstChar = 'A';
        private const char latinLastChar = 'Z';
        private const char numericFirstChar = '1';
        private const char numericLastChar = '9';

        public ShipValidator(UserContext userContext, string actionName, string serviceName)
        {
            this.RuleFor(x => x.ShipId)
                .Cascade(CascadeMode.Stop)
                .NotNull()
                .WithState(dto => new BusinessRuleViolationEventMessage(
                    EventMessageType.FAILED,
                    BusinessRuleValidationCodes.PropertyValueMissing,
                    userContext.UserId,
                    Guid.Empty,
                    "ShipId missing",
                    nameof(dto.ShipId),
                    Guid.Empty,
                    actionName,
                    serviceName))
                .NotEqual(Guid.Empty)
                .WithState(dto => new BusinessRuleViolationEventMessage(
                    EventMessageType.FAILED,
                    BusinessRuleValidationCodes.PropertyValueMissing,
                    userContext.UserId,
                    Guid.Empty,
                    "ShipId missing",
                    nameof(dto.ShipId),
                    Guid.Empty,
                    actionName,
                    serviceName))
                .DependentRules(() =>
                {
                    this.RuleFor(x => x.ShipName)
                        .Cascade(CascadeMode.Stop)
                        .NotNull()
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueMissing,
                            userContext.UserId,
                            dto.ShipId,
                            "ShipName missing",
                            nameof(dto.ShipName),
                            Guid.Empty,
                            actionName,
                            serviceName))
                        .NotEmpty()
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueMissing,
                            userContext.UserId,
                            dto.ShipId,
                            "ShipName missing",
                            nameof(dto.ShipName),
                            Guid.Empty,
                            actionName,
                            serviceName));

                    this.RuleFor(x => x.Dimensions)
                        .Cascade(CascadeMode.Stop)
                        .NotNull()
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueMissing,
                            userContext.UserId,
                            dto.ShipId,
                            "Dimensions missing",
                            nameof(dto.Dimensions),
                            dto.Dimensions,
                            actionName,
                            serviceName))
                        .NotEmpty()
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueMissing,
                            userContext.UserId,
                            dto.ShipId,
                            "Dimensions missing",
                            nameof(dto.Dimensions),
                            dto.Dimensions,
                            actionName,
                            serviceName))
                        .Must(this.DimensionsAreValid)
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueNotInCorrectFormat,
                            userContext.UserId,
                            dto.ShipId,
                            "Dimensions Are Invalid",
                            nameof(dto.Dimensions),
                            dto.Dimensions,
                            actionName,
                            serviceName));


                    this.RuleFor(x => x.Code)
                        .Cascade(CascadeMode.Stop)
                        .NotNull()
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueMissing,
                            userContext.UserId,
                            dto.ShipId,
                            "ShipCode missing",
                            nameof(dto.Code),
                            dto.Code,
                            actionName,
                            serviceName))
                        .NotEqual(string.Empty)
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueMissing,
                            userContext.UserId,
                            dto.ShipId,
                            "ShipCode missing",
                            nameof(dto.Code),
                            dto.Code,
                            actionName,
                            serviceName))
                        .Must(this.IsValidCode)
                        .WithState(dto => new BusinessRuleViolationEventMessage(
                            EventMessageType.FAILED,
                            BusinessRuleValidationCodes.PropertyValueNotInCorrectFormat,
                            userContext.UserId,
                            dto.ShipId,
                            "ShipCode is Invalid",
                            nameof(dto.Code),
                            dto.Code,
                            actionName,
                            serviceName));

                });


        }

        private bool IsValidCode(string shipCode)
        {
            shipCode = shipCode.Trim().ToUpper();
            var dashCount = shipCode.Where(x => x == seperationChar)?.Count();
            if (dashCount != 2)
            {
                return false;
            }

            var codes = shipCode.Split(seperationChar);
            if (codes.Count() != 3)
            {
                return false;
            }
            var x = codes[0].All(x => x >= latinFirstChar && x <= latinLastChar);
            return codes[0].Length == 4
                && codes[1].Length == 4
                && codes[2].Length == 2
                && codes[0].All(x => x >= latinFirstChar && x <= latinLastChar)
                && codes[1].All(x => x >= numericFirstChar && x <= numericLastChar)
                && (codes[2][0] >= latinFirstChar && codes[2][0] <= latinLastChar)
                && (codes[2][1] >= numericFirstChar && codes[2][1] <= numericLastChar);
        }

        private bool DimensionsAreValid(IEnumerable<DimensionDto> dimensions)
        {
            foreach (var dimension in dimensions)
            {
                if (dimension.DimensionId == Guid.Empty || dimension.Height <= 0 || dimension.Width <= 0 || string.IsNullOrWhiteSpace(dimension.Unit))
                {
                    return false;
                }
            }

            if (dimensions.Select(x => x.Unit).Distinct().Count() != dimensions.Count())
            {
                return false;
            }

            if (dimensions.Select(x => x.DimensionId).Distinct().Count() != dimensions.Count())
            {
                return false;
            }

            return true;
        }
    }
}
