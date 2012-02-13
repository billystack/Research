using System;
using DDD.ATM.UI.Presenters;


namespace DDD.ATM.UI.Views
{
	public interface ILoginForm
	{
		void Display(
			DDD.ATM.UI.Presenters.LoginPresenter subject);
	}
}
