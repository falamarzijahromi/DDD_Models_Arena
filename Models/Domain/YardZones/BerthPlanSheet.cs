using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.YardZones
{
    public class BerthPlanSheet
    {
        public List<BerthPlanPoint> Points { get; private set; } = new();

        internal void SetTotalDistance(int distanceInMeter)
        {
            throw new NotImplementedException();
        }

        internal void AddPlanPoints(int fromMeter, int toMeter, DateTime fromDate, DateTime toDate, int voyageNumber)
        {
            var newPoints = CreateNewPoints(fromMeter, toMeter, fromDate, toDate, voyageNumber);

            var conflictedPoints = Points.AsParallel().Where(p => newPoints.Any(np => np.Date == p.Date && np.ZoneMeter == p.ZoneMeter));

            if (conflictedPoints.Any())
            {
                var errorMessgae = CreateConflictErrorMessage(conflictedPoints);

                throw new Exception(errorMessgae);
            }

            Points.AddRange(newPoints);
        }

        private string CreateConflictErrorMessage(IEnumerable<BerthPlanPoint> conflictedPoints)
        {
            var conflictedVoyageNames = conflictedPoints.GroupBy(p => p.VoyageNumber);

            var conflictedVoyages = conflictedVoyageNames.Aggregate(new StringBuilder(), (seed, point) => seed.Append($"{point.Key}."));

            return $"Ordered Berth Plan Has Conflicts With These Voyages: {conflictedVoyages}";
        }

        private IEnumerable<BerthPlanPoint> CreateNewPoints(int fromMeter, int toMeter, DateTime fromDate, DateTime toDate, int voyageNumber)
        {
            for (var i = fromMeter; i <= toMeter; i++)
            {
                for (var j = toDate; j <= fromDate; j.AddHours(1))
                {
                    yield return new(i, j, voyageNumber);
                }
            }
        }
    }
}