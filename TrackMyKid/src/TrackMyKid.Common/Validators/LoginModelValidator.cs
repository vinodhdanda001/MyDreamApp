using FluentValidation;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(m => m.UserName)
                .NotEmpty()
                .WithMessage("'Username' should not be empty");

            RuleFor(m => m.Password)
                .NotEmpty()
                .WithMessage("'Password' should not be empty");

            RuleFor(m => m.OrganizationId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("'Organisation Id' should not be empty or zero");
        }
    }
}
