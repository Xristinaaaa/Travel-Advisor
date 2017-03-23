using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using TravelAdvisor.Business.Services.Logic.Contracts;

namespace TravelAdvisor.Business.Services.Logic
{
	public class EmailService : IIdentityMessageService, IEmailService
	{
		public Task SendAsync(IdentityMessage message)
		{
			// Plug in your email service here to send an email.
			return Task.FromResult(0);
		}
	}
}
