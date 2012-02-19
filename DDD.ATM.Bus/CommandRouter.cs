using System;
using System.Collections.Generic;


namespace DDD.ATM.Bus
{
	public class CommandRouter : DDD.ATM.Bus.ICommandRouter
	{
		private Dictionary<Type, dynamic> c_routes;


		public CommandRouter()
		{
			this.c_routes = new Dictionary<Type, dynamic>();
		}


		public void Register<TCommand>(
			Action<TCommand> commandHandler) where TCommand : DDD.ATM.Commands.ICommand
		{
			if(this.c_routes.ContainsKey(typeof(TCommand)))
			{
				// TODO: BS 19/02/2012 Throw an exception here as a command cannot be added twice
			}

			this.c_routes.Add(typeof(TCommand), commandHandler);
		}


		public void Route(
			dynamic command)
		{
			var _commandHandler = this.c_routes[command.GetType()];
			// TODO: BS 19/02/2012 Throw an exception here if null...

			_commandHandler.Invoke(command);
			//_commandHandler.Invoke(command);
		}

	}
}
