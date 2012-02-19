using System;
using IOCContainer = DDD.ATM.UI.IOC.Container;


namespace DDD.ATM.UI.Presenters
{
	public class LoginPresenter : DDD.ATM.UI.Presenters.ILoginPresenter
	{
		private readonly DDD.ATM.UI.Views.ILoginForm c_view;


		public LoginPresenter(
			DDD.ATM.UI.Views.ILoginForm subject)
		{
			this.c_view = subject;	
		}


		public void AttemptLogin()
		{
			var _command = new DDD.ATM.Commands.CustomerAttemptingLogin(
				this.c_view.Username,
				this.c_view.Password);
		}


		public void Display()
		{
			this.c_view.Display(this);
		}
	}
}