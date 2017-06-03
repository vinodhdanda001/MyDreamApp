using FluentValidation;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.Validators
{
    public class TripModelValidator : AbstractValidator<TripModel>
    {
        public TripModelValidator()
        {
            RuleFor(m => m.VehicleId)
                .GreaterThan(0)
                .WithMessage("'Vehicle Id' should be a valid value");
            RuleFor(m => m.OrganizationId)
                .GreaterThan(0)
                .WithMessage("'Organisation Id' should be a valid value");
            RuleFor(m => m.DriverId)
                .NotEmpty()
                .WithMessage("'Driver Id' cannot be empty");
            RuleFor(m => m.RouteId)
                .NotEmpty()
                .WithMessage("'Route Id' cannot be empty");
            RuleFor(m => m.TripId)
                .NotEmpty()
                .WithMessage("'Trip Id' cannot be empty");
            RuleFor(m => m.TripSessionId)
                .GreaterThan(0)
                .WithMessage("'Trip session Id' should be a valid value");
            //TODO: Data time validations for triptime, start and end time
        }
    }
}
