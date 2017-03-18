﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace TravelAdvisor.Business.Data.Contracts
{
	public interface IEFRepository<T> where T : class
	{
		IQueryable<T> Entities { get; }

		IQueryable<T> All();

		T GetById(object id);

		T GetFirst(Expression<Func<T, bool>> filter);

		void Add(T entity);

		void Update(T entity);

		void Delete(T entity);
	}
}
