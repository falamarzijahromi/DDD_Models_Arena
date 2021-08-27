using System;

namespace Domain.Voyages
{
    public class BerthPlan
    {
        public BerthPlan(int FromMeter, int ToMeter, DateTime FromDate, DateTime ToDate)
        {
            this.FromMeter = FromMeter;
            this.ToMeter = ToMeter;
            this.FromDate = FromDate;
            this.ToDate = ToDate;
        }

        public int FromMeter { get; private set; }
        public int ToMeter { get; private set; }
        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
    }
}