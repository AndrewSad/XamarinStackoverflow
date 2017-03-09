using System;
namespace stackoverflown
{
	public class Constants
	{
		public static string stackoverflowQuery = "https://api.stackexchange.com/2.2/questions?order=desc&sort=activity&page=20&tagged={0}&site=stackoverflow&filter=!gB7hjL3lhJ*Cnfe63rh6pC_qBj).1ki33j5";
		public static string stackoverflowAnswersQuery = "http://api.stackexchange.com/2.2/questions/{0}/answers??order=desc&sort=activity&page=20&site=stackoverflow&filter=!gB7hjL3lhJ*Cnfe63rh6pC_qBj).1ki33j5";

	}
}
