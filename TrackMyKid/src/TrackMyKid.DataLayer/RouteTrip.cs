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
    
    public partial class RouteTrip
    {
        public int row_id { get; set; }
        public int Organization_ID { get; set; }
        public int Route_ID { get; set; }
        public string TripId { get; set; }
        public string LastUpdatedBy { get; set; }
        public string IsActive { get; set; }
        public System.DateTime cr_datetime { get; set; }
        public System.DateTime updt_datetime { get; set; }
    }
}
