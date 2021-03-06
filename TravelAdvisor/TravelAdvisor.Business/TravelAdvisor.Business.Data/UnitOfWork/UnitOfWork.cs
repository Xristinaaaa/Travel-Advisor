﻿using Bytes2you.Validation;
using TravelAdvisor.Business.Data.Contracts;

namespace TravelAdvisor.Business.Data.UnitOfWork
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly ITravelAdvisorDbContext context;

		public UnitOfWork(ITravelAdvisorDbContext context)
		{
			Guard.WhenArgument(context, "Db context is null!").IsNull().Throw();

			this.context = context;
		}

		public void SaveChanges()
		{
			this.context.SaveChanges();
		}

		public void Dispose()
		{

		}
	}
}
