using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(LoginModelValidator))]
    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int OrganizationId { get; set; }
    }
}
