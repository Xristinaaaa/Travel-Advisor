using Ninject.Modules;
using TravelAdvisor.Business.Data;
using TravelAdvisor.Business.Data.Contracts;
using TravelAdvisor.Business.Data.Repositories;
using TravelAdvisor.Business.Data.UnitOfWork;

namespace TravelAdvisor.Web.App_Start.NinjectBindings
{
	public class DataBindings : NinjectModule
	{
		public override void Load()
		{
			this.Bind(typeof(IEFRepository<>)).To(typeof(EFRepository<>));
			this.Bind<ITravelAdvisorDbContext>().To<TravelAdvisorDbContext>().InSingletonScope();
			this.Bind<IUnitOfWork>().To<UnitOfWork>();
		}
	}
}