using System.Linq;
using Bytes2you.Validation;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Services.Data.Contracts;

namespace TravelAdvisor.Business.Services.Data
{
	public class TripService : ITripService
	{
		private readonly IEFRepository<Trip> tripRepository;
		private readonly IUnitOfWork unitOfWork;

		public TripService(IEFRepository<Trip> tripRepository, IUnitOfWork unitOfWork)
		{
			Guard.WhenArgument(tripRepository, "Trip repository is null!").IsNull().Throw();
			Guard.WhenArgument(unitOfWork, "Unit of work is null!").IsNull().Throw();

			this.tripRepository = tripRepository;
			this.unitOfWork = unitOfWork;
		}

		public void AddTrip(Trip tripToAdd)
		{
			Guard.WhenArgument(tripToAdd, "Trip to add is null").IsNull().Throw();

			using (var uow = this.unitOfWork)
			{
				this.tripRepository.Add(tripToAdd);
				uow.SaveChanges();
			}
		}

		public Trip FindTrip(int id)
		{
			return this.tripRepository.GetFirst(x => x.Id == id);
		}

		public IQueryable<Trip> GetAllTrips()
		{
			return this.tripRepository.All();
		}
	}
}
