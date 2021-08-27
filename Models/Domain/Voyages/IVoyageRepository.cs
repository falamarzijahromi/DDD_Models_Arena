using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Voyages
{
    public interface IVoyageRepository
    {
        Task<Voyage> GetVoyage(int voyageNumber);
        Task Update(Voyage voyage);
    }
}
