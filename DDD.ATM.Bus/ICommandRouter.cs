using System;


namespace DDD.ATM.Bus
{
	public interface ICommandRouter
	{
		void Register<TCommand>(
			Action<TCommand> commandHandler) where TCommand : DDD.ATM.Commands.ICommand;

		void Route(
			dynamic command);
	}
}