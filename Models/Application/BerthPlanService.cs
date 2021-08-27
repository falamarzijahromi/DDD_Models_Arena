using Application.Contracts;
using Domain.Voyages;
using Domain.YardZones;
using System.Threading.Tasks;

namespace Application
{
    public class BerthPlanService
    {
        private readonly IVoyageRepository voyageRepository;
        private readonly IYardZoneRepository yardZoneRepository;

        public BerthPlanService(IVoyageRepository voyageRepository, IYardZoneRepository yardZoneRepository)
        {
            this.voyageRepository = voyageRepository;
            this.yardZoneRepository = yardZoneRepository;
        }

        public async Task CreateBerthPlan(BerthPlanDTO berthPlanDTO)
        {
            var voyage = await voyageRepository.GetVoyage(berthPlanDTO.VoyageNumber);

            var zone = await yardZoneRepository.GetZone(berthPlanDTO.ZoneNumber);

            BerthPlan berthPlan = new(berthPlanDTO.FromMeter, berthPlanDTO.ToMeter, berthPlanDTO.FromDate, berthPlanDTO.ToDate);

            zone.SetBerthPlan(voyage, berthPlan);

            await voyageRepository.Update(voyage);

            await yardZoneRepository.Update(zone);
        }
    }
}
