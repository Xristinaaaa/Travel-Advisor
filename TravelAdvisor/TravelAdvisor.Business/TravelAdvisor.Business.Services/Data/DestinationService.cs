using System.Linq;
using Bytes2you.Validation;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Services.Data.Contracts;

namespace TravelAdvisor.Business.Services.Data
{
	public class DestinationService : IDestinationService
	{
		private readonly IEFRepository<Destination> destinationRepository;
		private readonly IUnitOfWork unitOfWork;

		public DestinationService(IEFRepository<Destination> destinationRepository, IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(destinationRepository, "Destination repository is null!").IsNull().Throw();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

			this.destinationRepository = destinationRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddDestination(Destination destinationToAdd)
		{
			Guard.WhenArgument(destinationToAdd, "Destination to add is null").IsNull().Throw();

			using (var uow = this.unitOfWork)
			{
				this.destinationRepository.Add(destinationToAdd);
				uow.SaveChanges();
			}
		}

		public IQueryable<Destination> GetDestinations(int startAt, int count)
		{
			return this.destinationRepository.All().OrderByDescending(x => x.Id).Skip(startAt).Take(count);
		}

		public IQueryable<Destination> GetAllDestinations()
		{
			return this.destinationRepository.All();
		}
	}
}
