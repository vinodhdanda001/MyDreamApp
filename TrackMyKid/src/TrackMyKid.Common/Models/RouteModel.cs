﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class RouteModel
    {
        public int Organization_ID { get; set; }
        public int Route_ID { get; set; }
        public string Route_Display_Name { get; set; }
        public string End_Halt { get; set; }
    }
}
