using System;
using System.Collections.Generic;


namespace DDD.ATM.Bus
{
	public class CommandRouter
	{
		private Dictionary<Type, Action<DDD.ATM.Commands.ICommand>> c_routes;


		public CommandRouter()
		{
			this.c_routes = new Dictionary<Type, Action<DDD.ATM.Commands.ICommand>>();
		}

		public void Register<TCommand>(
			Action<TCommand> commandHandler) where TCommand : DDD.ATM.Commands.ICommand
		{
			if(this.c_routes.ContainsKey(typeof(TCommand)))
			{
				// TODO: BS 19/02/2012 Throw an exception here as a command cannot be added twice
			}

			this.c_routes.Add(typeof(TCommand), commandHandler as Action<DDD.ATM.Commands.ICommand>);
		}



		public void Route(object message)
		{
			//ICollection<Action<object>> routes;

			////if (!_routes.TryGetValue(message.GetType(), out routes))
			////	throw new RouteNotRegisteredException(message.GetType());

			//foreach (var route in routes)
			//    route(message);
		}

	}
}
