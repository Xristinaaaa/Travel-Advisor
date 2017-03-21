using Ninject.Modules;
using Ninject.Web.Common;
using TravelAdvisor.Business.Services.Data;
using TravelAdvisor.Business.Services.Data.Contracts;
using TravelAdvisor.Business.Services.Logic;
using TravelAdvisor.Business.Services.Logic.Contracts;

namespace TravelAdvisor.Web.App_Start.NinjectBindings
{
	public class ServicesBindings : NinjectModule
	{
		public override void Load()
		{
			this.Bind<IDestinationService>().To<DestinationService>().InRequestScope();
			this.Bind<IRegistrationService>().To<RegistrationService>().InRequestScope();
			this.Bind<IMappingService>().To<MappingService>().InRequestScope();
		}
	}
}