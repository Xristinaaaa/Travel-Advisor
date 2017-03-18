using Ninject.Extensions.Conventions;
using Ninject.Modules;

namespace TravelAdvisor.Web.App_Start.NinjectBindings
{
	public class ServicesBindings : NinjectModule
	{
		public override void Load()
		{
			this.Bind(x => x.From("TravelAdvisor.Business.Services").SelectAllClasses().BindDefaultInterface());
		}
	}
}