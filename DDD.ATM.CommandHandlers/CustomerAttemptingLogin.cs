using System;


namespace DDD.ATM.CommandHandlers
{
	public class CustomerAttemptingLogin
	{
		public void Execute(
			DDD.ATM.Commands.CustomerAttemptingLogin cancelReportStolenBankCardCommand)
		{
			Console.WriteLine("Got to here");
		}
	}
}
