using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackMyKid.Common.Models
{
    public class HaltModel
    {
        public string HaltName { get; set; }
        public int Seq_No { get; set; }
        public string Halt_Address { get; set; }
        public decimal X_Coordinate { get; set; }
        public decimal Y_Coordinate { get; set; }
    }
}
