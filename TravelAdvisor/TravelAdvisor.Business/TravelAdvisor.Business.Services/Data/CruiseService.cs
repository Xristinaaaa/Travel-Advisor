using Bytes2you.Validation;
using System.Linq;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Business.Services.Data.Contracts;

namespace TravelAdvisor.Business.Services.Data
{
    public class CruiseService : ICruiseService
    {
        private readonly IEFRepository<Cruise> cruiseRepository;
        private readonly IUnitOfWork unitOfWork;
        public CruiseService(IEFRepository<Cruise> cruiseRepository, IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(cruiseRepository, "Cruise repository is null!").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

            this.cruiseRepository = cruiseRepository;
            this.unitOfWork = unitOfWork;
        }
        public void AddCruise(Cruise cruiseToAdd)
        {
            Guard.WhenArgument(cruiseToAdd, "Cruise to add is null").IsNull().Throw();

            using (var uow = this.unitOfWork)
            {
                this.cruiseRepository.Add(cruiseToAdd);
                uow.SaveChanges();
            }
        }

        public IQueryable<Cruise> GetAll()
        {
            return this.cruiseRepository.All();
        }
    }
}
