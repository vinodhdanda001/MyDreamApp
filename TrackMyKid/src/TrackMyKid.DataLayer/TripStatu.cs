//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TrackMyKid.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class TripStatu
    {
        public int TripSessionId { get; set; }
        public int Organization_ID { get; set; }
        public int Route_ID { get; set; }
        public int TripId { get; set; }
        public string TripStatusCode { get; set; }
        public Nullable<System.DateTime> TripStartTime { get; set; }
        public Nullable<System.DateTime> TripEndTime { get; set; }
        public string Driver_ID { get; set; }
        public Nullable<int> Vehicle_ID { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> cr_datetime { get; set; }
        public Nullable<System.DateTime> updt_datetime { get; set; }
    }
}
