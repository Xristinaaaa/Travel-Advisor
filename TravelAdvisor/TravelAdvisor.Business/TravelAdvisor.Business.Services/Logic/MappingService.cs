using AutoMapper;
using TravelAdvisor.Business.Services.Logic.Contracts;

namespace TravelAdvisor.Business.Services.Logic
{
	public class MappingService : IMappingService
	{
		public T Map<T>(object source)
		{
			return Mapper.Map<T>(source);
		}

		public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
		{
			return Mapper.Map<TSource, TDestination>(source, destination);
		}

		public TDestination Map<TSource, TDestination>(TSource source)
		{
			return Mapper.Map<TSource, TDestination>(source);
		}
	}
}
