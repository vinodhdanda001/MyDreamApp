using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(RegisterModelValidator))]
    public class RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int OrganizationId { get; set; }
        public int PrimaryContactNum { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public int otp { get; set; }
    }
}
