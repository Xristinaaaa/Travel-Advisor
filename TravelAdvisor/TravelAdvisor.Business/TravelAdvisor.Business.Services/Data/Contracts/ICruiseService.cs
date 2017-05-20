using System.Linq;
using TravelAdvisor.Business.Models.Cruises;

namespace TravelAdvisor.Business.Services.Data.Contracts
{
    public interface ICruiseService
    {
        IQueryable<Cruise> GetAll();

        void AddCruise(Cruise cruiseToAdd);
    }
}
