using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Models.Booking;
using TravelAdvisor.Business.Models.Cruises;
using TravelAdvisor.Business.Models.Destinations;
using TravelAdvisor.Business.Models.Trips;
using TravelAdvisor.Business.Models.Users;

namespace TravelAdvisor.Business.Data
{
	public class TravelAdvisorDbContext : IdentityDbContext<ApplicationUser>, ITravelAdvisorDbContext
	{
		public TravelAdvisorDbContext()
            : base("TravelAdvisor", throwIfV1Schema: false)
        {
		}

		public virtual DbSet<Admin> Admins { get; set; }

		public virtual DbSet<RegularUser> RegularUsers { get; set; }

		public virtual DbSet<Trip> Trips { get; set; }

		public virtual DbSet<Destination> Destinations { get; set; }

		public virtual DbSet<Cruise> Cruises { get; set; }

		public virtual DbSet<CarRental> CarRentals { get; set; }

		public virtual DbSet<Flight> Flights { get; set; }

		public static TravelAdvisorDbContext Create()
		{
			return new TravelAdvisorDbContext();
		}

		IDbSet<T> ITravelAdvisorDbContext.Set<T>()
		{
			return base.Set<T>();
		}

		void ITravelAdvisorDbContext.SaveChanges()
		{
			base.SaveChanges();
		}
	}
}
