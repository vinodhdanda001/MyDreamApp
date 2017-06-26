using FluentValidation;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.Validators
{
    public class GeoLocationModelValidator : AbstractValidator<GeoLocation>
    {
        public GeoLocationModelValidator()
        {
            RuleFor(m => m.DriverID)
                .NotEmpty()
                .WithMessage("'Driver Id' cannot be empty");

            RuleFor(m => m.Lattitude)
                .NotEmpty()
                .WithMessage("'Latitude' cannot be empty");

            RuleFor(m => m.Longitude)
                .NotEmpty()
                .WithMessage("'Longitude' cannot be empty");

            RuleFor(m => m.TripSessionId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("'Trip session id' cannot be empty or zero");
        }
    }
}
