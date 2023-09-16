using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APICamionero.Controllers
{
    public class GetDestinationView
    {
        public int IDDestination { get; set; }
        public string StreetDestination { get; set; }
        public int DoorNumber { get; set; }
        public string CornerDestination { get; set; }
        public bool ActivedDestination { get; set; }
    }
}