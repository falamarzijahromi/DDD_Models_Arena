using Domain.Voyages;
using System.Collections.Generic;

namespace Domain.YardZones
{
    public class YardZone
    {
        public int Number { get; private set; }
        
        public List<Berth> Berths { get; private set; } = new();

        public int DistanceInMeter { get; private set; }

        public ZoneDistance ZoneDistance { get; private set; } = new();

        public BerthPlanSheet BerthPlanSheet { get; private set; } = new();

        public YardZone(int number, int distanceInMeter)
        {
            Number = number;

            ZoneDistance.SetTotalDistance(distanceInMeter);

            BerthPlanSheet.SetTotalDistance(distanceInMeter);

            DistanceInMeter = distanceInMeter;
        }

        public void SetBerth(int fromMeter, int toMeter, string name)
        {
            ZoneDistance.AddPoints(fromMeter, toMeter, name);

            Berth newBerth = new(name, fromMeter, toMeter);

            Berths.Add(newBerth);
        }

        public void SetBerthPlan(Voyage forVoyage, BerthPlan berthPlan)
        {
            forVoyage.SetBerthPlan(berthPlan);

            BerthPlanSheet.AddPlanPoints(berthPlan.FromMeter, berthPlan.ToMeter, berthPlan.FromDate, berthPlan.ToDate, forVoyage.Number);
        }
    }
}
