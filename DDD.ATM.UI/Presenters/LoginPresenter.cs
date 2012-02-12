using System;


namespace DDD.ATM.UI.Presenters
{
	public class LoginPresenter : DDD.ATM.UI.Presenters.ILoginPresenter
	{
		public bool AttemptLogin()
		{
			throw new NotImplementedException();
		}


		public void Display()
		{
			new DDD.ATM.UI.Views.LoginForm().ShowDialog();
		}
	}
}