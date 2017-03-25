namespace TravelAdvisor.Business.Common.Constants
{
	public class ValidationConstants
	{
		//User
		public const int NameMinLength = 2;
		public const int NameMaxLength = 50;

		public const int MinAge = 18;
		public const int MaxAge = 99;

		//Destination
		public const int MinCountryLength = 5;
		public const int MaxCountryLength = 100;

		public const int MinDestinationDescriptionLength = 10;
		public const int MaxDestinationDescriptionLength = 10000;

		//Trip
		public const int MinTripDescriptionLength = 5;
		public const int MaxTripDescriptionLength = 10000;

		//Cruise
		public const int MinCruiseDescriptionLength = 5;
		public const int MaxCruiseDescriptionLength = 10000;

		//Car
		public const int MinCarDescriptionLength = 5;
		public const int MaxCarDescriptionLength = 10000;

		//Message
		public const int MinMessageText = 2;
		public const int MaxMessageText = 100000;
	}
}
