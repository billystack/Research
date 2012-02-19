using System;


namespace DDD.ATM.CommandHandlers
{
	public class CustomerAttemptingLogin
	{
		public void Execute(
			DDD.ATM.Commands.CustomerAttemptingLogin cancelReportStolenBankCardCommand)
		{
			Console.WriteLine("Got to here");


			// TODO; BS 19/02/2012 Pending questions
			// Now need to answer a few questions...
			// Firstly, do I go through an "aggregate root to perform this operation?
			// Or do I go straight to the event store

			// I am assuming I must execute some method that is associated with an aggregate root where the
			// commands corresponding event generated will be stored

			// Where will the chack against the event store occur to see if the customer exists or not

			// Is there a customer aggregate root?
		}
	}
}
