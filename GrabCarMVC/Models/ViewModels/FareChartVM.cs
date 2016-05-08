using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GrabCarMVC.Models.ViewModels
{
    public class FareChartVM
    {
       
        public string ServiceType1 { get; set; }

        public string TimeSlot { get; set; }

        public decimal? PickUp { get; set; }

        public decimal? PerKiloCost { get; set; }
          
    }
}