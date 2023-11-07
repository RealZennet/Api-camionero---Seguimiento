using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICamionero.Controllers
{
    public class GetTrackBatchWithIDView
    {
        public int LoteId { get; set; }
        public string StreetDestination { get; set; }
        public string DoorNumber { get;  set; }
        public string CornerDestination { get; set; }
        public DateTime ShippmentDate { get; set; }
    }
}