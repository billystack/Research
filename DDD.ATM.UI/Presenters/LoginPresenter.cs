using System;
using IOCContainer = DDD.ATM.UI.IOC.Container;


namespace DDD.ATM.UI.Presenters
{
	public class LoginPresenter : DDD.ATM.UI.Presenters.ILoginPresenter
	{
		private readonly DDD.ATM.UI.Views.ILoginForm c_view;
		private readonly DDD.ATM.Bus.ICommand c_commandBus;


		public LoginPresenter(
			DDD.ATM.UI.Views.ILoginForm view,
			DDD.ATM.Bus.ICommand commandBus)
		{
			this.c_view = view;
			this.c_commandBus = commandBus;
		}


		public void AttemptLogin()
		{
			var _command = new DDD.ATM.Commands.CustomerAttemptingLogin(
				this.c_view.Username,
				this.c_view.Password);

			this.c_commandBus.Publish(_command);
		}


		public void Display()
		{
			this.c_view.Display(this);
		}
	}
}