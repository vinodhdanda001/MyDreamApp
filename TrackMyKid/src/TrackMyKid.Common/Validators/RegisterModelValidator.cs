using FluentValidation;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.Validators
{
    public class RegisterModelValidator : AbstractValidator<RegisterModel>
    {
        public RegisterModelValidator()
        {
            RuleFor(m => m.UserName)
                .NotEmpty()
                .WithMessage("'Username' cannot be empty");
            RuleFor(m => m.OrganizationId)
                .NotEmpty()
                .WithMessage("'Organisation Id' cannot be empty");
            RuleFor(m => m.Password)
                .NotEmpty()
                .WithMessage("'Password' cannot be empty");
            RuleFor(m => m.PrimaryContactNum)
                .NotEmpty()
                .WithMessage("'Contact No' cannot be empty");
            RuleFor(m => m.PasswordSalt)
                .NotEmpty()
                .WithMessage("'Password salt' cannot be empty");
        }
    }
}
