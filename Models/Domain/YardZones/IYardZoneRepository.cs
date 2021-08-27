using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.YardZones
{
    public interface IYardZoneRepository
    {
        Task<YardZone> GetZone(int zoneNumber);
        Task Update(YardZone zone);
    }
}
