using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(UserProfileValidator))]
    public class UserProfile
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int OrganizationId { get; set; }
        public int RouteID { get; set; }
        public string RouteDisplayName { get; set; }
        public int TripId { get; set; }
        public string Address { get; set; }
        public string FullName => FirstName + " " + LastName;
    }
}
