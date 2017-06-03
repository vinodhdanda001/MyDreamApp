using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(GeoLocationModelValidator))]
    public class GeoLocation
    {
        public int TripSessionId { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longitude { get; set; }
        public string DriverID { get; set; }
    }
}
