using System;


namespace DDD.ATM.Bus
{
	public interface ICommand
	{
		void Publish(
			DDD.ATM.Commands.ICommand command);
	}
}