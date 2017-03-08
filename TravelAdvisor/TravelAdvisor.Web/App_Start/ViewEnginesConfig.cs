using System.Web.Mvc;

namespace TravelAdvisor.Web
{
	public class ViewEnginesConfig
	{
		public static void RegisterViewEngines()
		{
			ViewEngines.Engines.Clear();
			ViewEngines.Engines.Add(new RazorViewEngine());
		}
	}
}