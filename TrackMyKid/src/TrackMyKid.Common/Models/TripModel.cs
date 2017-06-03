using System;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(TripModelValidator))]
    public class TripModel
    {
        public string TripId  { get; set; }
        public DateTime TripTime { get; set; }
        public int OrganizationId { get; set; }
        public int TripSessionId { get; set; }
        public string RouteId { get; set; }
        public string DriverId { get; set; }
        public int VehicleId { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime TripStartTime { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime TripEndTime { get; set; }
    }

    public enum TripStatusCode
    {
        Invalid,
        InProgress,
        Completed
    }
}
