using FluentValidation;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.Validators
{
    public class UserProfileValidator : AbstractValidator<UserProfile>
    {
        public UserProfileValidator()
        {
            RuleFor(m => m.UserName)
                .NotEmpty()
                .WithMessage("'Username' cannot be empty");
            RuleFor(m => m.Address)
                .NotEmpty()
                .WithMessage("'Address' cannot be empty");
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .WithMessage("'FirstName' cannot be empty");
            RuleFor(m => m.LastName)
                .NotEmpty()
                .WithMessage("'LastName' cannot be empty");
            RuleFor(m => m.RouteDisplayName)
                .NotEmpty()
                .WithMessage("'Route display name' cannot be empty");
            RuleFor(m => m.RouteID)
                .NotEmpty()
                .WithMessage("'Route Id' cannot be empty");
            RuleFor(m => m.TripId)
                .NotEmpty()
                .WithMessage("'Trip Id' cannot be empty");
            RuleFor(m => m.OrganizationId)
                .GreaterThan(0)
                .WithMessage("'Organisation Id' should be valid");
        }
    }
}
