using System;

namespace Domain.YardZones
{
    public class BerthPlanPoint
    {
        public BerthPlanPoint(int ZoneMeter, DateTime Date, int VoyageNumber)
        {
            this.ZoneMeter = ZoneMeter;
            this.Date = Date;
            this.VoyageNumber = VoyageNumber;
        }

        public int ZoneMeter { get; private set; }
        public DateTime Date { get; private set; }
        public int VoyageNumber { get; private set; }
    }
}