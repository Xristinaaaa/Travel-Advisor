using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace TravelAdvisor.Business.Services.Logic.Contracts
{
	public interface IEmailService
	{
		Task SendAsync(IdentityMessage message);
	}
}
