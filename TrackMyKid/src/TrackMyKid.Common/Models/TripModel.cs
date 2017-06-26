using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FluentValidation.Attributes;
using TrackMyKid.Common.Validators;

namespace TrackMyKid.Common.Models
{
    [Validator(typeof(TripModelValidator))]
    public class TripModel
    {
        public int TripId  { get; set; }
        //public string Route_ID { get; set; }
        public DateTime TripTime { get; set; }
        public int organizationId { get; set; }
        public int TripSessionID { get; set; }
        public int RouteID { get; set; }
        public string DriverId { get; set; }
        public int VehicleID { get; set; }
        public TripStatusCode TripStatusCd { get; set; }

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
