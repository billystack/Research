using System;
using IOCContainer = DDD.ATM.UI.IOC.Container;


namespace DDD.ATM.UI.Presenters
{
	public class LoginPresenter : DDD.ATM.UI.Presenters.ILoginPresenter
	{
		private DDD.ATM.UI.Views.ILoginForm c_view;


		public LoginPresenter(
			DDD.ATM.UI.Views.ILoginForm subject)
		{
			this.c_view = subject;	
		}


		public void AttemptLogin()
		{
			throw new NotImplementedException();
		}


		public void Display()
		{
			this.c_view.Display(this);
		}
	}
}