namespace TravelAdvisor.Business.Models.Users.Contracts
{
	public interface IAdmin
	{
		string Id { get; set; }

		ApplicationUser ApplicationUser { get; set; }

		bool IsDeleted { get; set; }
	}
}
