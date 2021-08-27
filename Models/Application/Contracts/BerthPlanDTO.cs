using System;

namespace Application.Contracts
{
    public class BerthPlanDTO
    {
        public int VoyageNumber { get; set; }
        public int ZoneNumber { get; set; }
        
        public int FromMeter { get; set; }
        public int ToMeter { get; set; }

        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
