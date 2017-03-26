using System.Collections.Generic;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Models.Users;
using TravelAdvisor.Business.Services.Data.Contracts;

namespace TravelAdvisor.Business.Services.Data
{
	public class UserService : IUserService
	{
		private readonly IEFRepository<RegularUser> regularUserRepository;
		private readonly IUnitOfWork unitOfWork;

		public UserService(IEFRepository<RegularUser> regularUserRepository, IUnitOfWork unitOfWork)
		{
			this.regularUserRepository = regularUserRepository;
			this.unitOfWork = unitOfWork;
		}

		public IEnumerable<Trip> GetUserTrips(string userId)
		{
			var user = this.regularUserRepository.GetById(userId);

			return user.Trips;
		}

		public void AddTripToWishlist(Trip tripToAdd, string userId)
		{
			var user = this.regularUserRepository.GetById(userId);

			user.Trips.Add(tripToAdd);
		}
	}
}
