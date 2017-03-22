using Ninject.Modules;
using Ninject.Web.Common;
using Ninject.Extensions.Conventions;
using TravelAdvisor.Web.App_Start.NinjectBindings.Constants;

namespace TravelAdvisor.Web.App_Start.NinjectBindings
{
	public class ServicesBindings : NinjectModule
	{
		public override void Load()
		{
			this.Bind(x => x.From(Assemblies.Services).SelectAllClasses().BindDefaultInterface().Configure(b => b.InRequestScope()));
		}
	}
}