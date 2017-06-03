using FluentValidation;
using TrackMyKid.Common.Models;

namespace TrackMyKid.Common.Validators
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m => m.FirstName)
                .NotEmpty()
                .WithMessage("'FirstName' cannot be empty");
            RuleFor(m => m.LastName)
                .NotEmpty()
                .WithMessage("'LastName cannot be empty'");
            RuleFor(m => m.Address)
                .NotEmpty()
                .WithMessage("'Address' cannot be empty");
            RuleFor(m => m.MemberId)
                .NotEmpty()
                .WithMessage("'MemberId' cannot be empty");
            RuleFor(m => m.Email)
                .EmailAddress()
                .WithMessage("'Email' cannot be empty");
            RuleFor(m => m.OrganizationId)
                .GreaterThan(0)
                .WithMessage("'Organisation Id' should be greater than 0");
            RuleFor(m => m.OrganizationName)
                .NotEmpty()
                .WithMessage("'Organisation name' cannot be empty");
            RuleFor(m => m.PinCode)
                .GreaterThan(0)
                .WithMessage("'Pin Code' should be valid");
            RuleFor(m => m.PrimaryContactNo)
                .GreaterThan(0)
                .WithMessage("'Contact number' should be valid");
        }
    }
}
