namespace Domain.YardZones
{
    public class Berth
    {
        public Berth(string Name, int FromMeter, int ToMeter)
        {
            this.Name = Name;
            this.FromMeter = FromMeter;
            this.ToMeter = ToMeter;
        }

        public string Name { get; private set; }
        public int FromMeter { get; private set; }
        public int ToMeter { get; private set; }
    }
}