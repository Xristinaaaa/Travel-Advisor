using System.Web;

namespace TravelAdvisor.Business.Services.Data.Contracts
{
	public interface IImageService
	{
		bool IsImageFile(HttpPostedFileBase file);
	}
}
