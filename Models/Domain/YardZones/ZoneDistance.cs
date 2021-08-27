using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.YardZones
{
    public class ZoneDistance
    {
        public List<DistancePoint> DistancePoints { get; private set; } = new();
        public int Total { get; internal set; }

        public void AddPoints(int fromMeter, int toMeter, string berthName)
        {
            var newDistancePoints = CreateDistancePoints(fromMeter, toMeter, berthName);

            var conflictedPoints = DistancePoints.AsParallel().Where(ndp => newDistancePoints.Any(dp => dp.MeterNumber == ndp.MeterNumber));

            if (conflictedPoints.Any())
            {
                var errorMessage = CreateConflictErrorMessage(conflictedPoints);

                throw new Exception(errorMessage);
            }

            DistancePoints.AddRange(newDistancePoints);
        }

        internal void SetTotalDistance(int distanceInMeter)
        {
            throw new NotImplementedException();
        }

        private string CreateConflictErrorMessage(IEnumerable<DistancePoint> conflictedPoints)
        {
            var conflictedBerthGroup = conflictedPoints.GroupBy(cp => cp.BerthName);

            var conflictedBerths = conflictedBerthGroup.Aggregate(new StringBuilder(), (seed, point) => seed.Append($"{point.Key},"));

            return $"Ordered Berth Plan Has Conflicts With These Plan: {conflictedBerths}";
        }

        private IEnumerable<DistancePoint> CreateDistancePoints(int fromMeter, int toMeter, string berthName)
        {
            for (int i = fromMeter; i <= toMeter; i++)
            {
                yield return new(i, berthName);
            }
        }
    }
}