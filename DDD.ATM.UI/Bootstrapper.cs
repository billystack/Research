using System;


namespace DDD.ATM.UI
{
	public class Bootstrapper
	{
		public void Bootstrap()
		{
			var _container = new DDD.ATM.UI.Container();

			_container.Register<DDD.ATM.UI.Presenters.ILoginPresenter>(delegate
				{
					return new DDD.ATM.UI.Presenters.LoginPresenter();
				});

		}
	}
}
