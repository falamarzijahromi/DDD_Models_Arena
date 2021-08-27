namespace Domain.YardZones
{
    public class DistancePoint
    {
        public DistancePoint(int MeterNumber, string BerthName)
        {
            this.MeterNumber = MeterNumber;
            this.BerthName = BerthName;
        }

        public int MeterNumber { get; private set; }
        public string BerthName { get; private set; }
    }
}