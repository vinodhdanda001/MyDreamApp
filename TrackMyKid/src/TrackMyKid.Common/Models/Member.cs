using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(MemberValidator))]
    public class Member
    {
        public string MemberId { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Address { get; set; }
        public string AddressLandMark { get; set; }
        public int PinCode { get; set; }
        public string Email { get; set; }
        public int PrimaryContactNo { get; set; }
        public int? AlternativeContactNo { get; set; }
    }
}
