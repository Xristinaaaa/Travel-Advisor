using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace TravelAdvisor.Business.Data.Contracts
{
	public interface ITravelAdvisorDbContext : IDisposable
	{
		IDbSet<T> Set<T>() where T : class;

		DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

		void SaveChanges();
	}
}
