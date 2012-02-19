using System;

namespace DDD.ATM.Bus
{
	public class Command : ICommand
	{
		private readonly DDD.ATM.Bus.ICommandRouter c_commandRouter;


		public Command(
			DDD.ATM.Bus.ICommandRouter commandRouter)
		{
			// TODO: BS 19/02/2012 DBC checks

			this.c_commandRouter = commandRouter;
		}


		public void Publish(
			DDD.ATM.Commands.ICommand command)
		{
			this.c_commandRouter.Route(command);
		}
	}
}
