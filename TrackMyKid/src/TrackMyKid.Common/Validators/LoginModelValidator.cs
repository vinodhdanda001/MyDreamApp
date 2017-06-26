using FluentValidation;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.Validators
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(m => m.userName)
                .NotEmpty()
                .WithMessage("'Username' should not be empty");

            RuleFor(m => m.passWord)
                .NotEmpty()
                .WithMessage("'Password' should not be empty");

            RuleFor(m => m.organizationId)
                .NotEmpty()
                .GreaterThan(0)
                .WithMessage("'Organisation Id' should not be empty or zero");
        }
    }
}
