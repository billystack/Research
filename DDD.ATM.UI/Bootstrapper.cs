using System;


namespace DDD.ATM.UI
{
	/// <summary>
	/// TODO: BS 12/02/12 This will move out into its own assembly later on ...
	/// </summary>
	public class Bootstrapper
	{
		public void Bootstrap()
		{
			var _container = DDD.ATM.UI.IOC.Container.Instance;

			_container.Register<DDD.ATM.Bus.ICommandRouter>(delegate
				{
					var _commandBus = new DDD.ATM.Bus.CommandRouter();
					_commandBus.Register<DDD.ATM.Commands.CustomerAttemptingLogin>(
						new DDD.ATM.CommandHandlers.CustomerAttemptingLogin().Execute);

					return _commandBus;
				});

			_container.Register<DDD.ATM.Bus.ICommand>(delegate
				{
					return new DDD.ATM.Bus.Command(_container.Create<DDD.ATM.Bus.ICommandRouter>());
				});

			_container.Register<DDD.ATM.UI.Presenters.ILoginPresenter>(delegate
				{
					return new DDD.ATM.UI.Presenters.LoginPresenter(
						new DDD.ATM.UI.Views.LoginForm(),
						_container.Create<DDD.ATM.Bus.ICommand>());
				});
		}
	}
}
