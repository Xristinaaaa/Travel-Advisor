using Ninject.Extensions.Conventions;
using Ninject.Modules;
using TravelAdvisor.Web.App_Start.NinjectBindings.Constants;

namespace TravelAdvisor.Web.App_Start.NinjectBindings
{
	public class ModelsBindings : NinjectModule
	{
		public override void Load()
		{
			this.Bind(x => x.From(Assemblies.Models).SelectAllClasses().BindDefaultInterface());
		}
	}
}