namespace TrackMyKid.Common.Models
{
    public class GeoLocation
    {
        public int TripSessionId { get; set; }
        public decimal Lattitude { get; set; }
        public decimal Longitude { get; set; }
        public string LastUpdatedBy { get; set; }
    }
}
