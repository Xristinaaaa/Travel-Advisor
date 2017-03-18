using System;

namespace TravelAdvisor.Business.Data.Contracts
{
	public interface IUnitOfWork : IDisposable
	{
		void SaveChanges();
	}
}
