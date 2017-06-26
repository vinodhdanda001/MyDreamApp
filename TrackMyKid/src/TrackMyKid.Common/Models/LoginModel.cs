using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(LoginModelValidator))]
    public class LoginModel
    {
        public string userName { get; set; }
        public string passWord { get; set; }
        public int organizationId { get; set; }
        public string FcmTokenId { get; set; }
    }
}
