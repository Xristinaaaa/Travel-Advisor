using AutoMapper;

namespace TravelAdvisor.Web.App_Start.AutoMapper
{
	public interface IHaveCustomMappings
	{
		void CreateMappings(IMapperConfigurationExpression configuration);
	}
}