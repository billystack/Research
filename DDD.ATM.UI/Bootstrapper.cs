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

			_container.Register<DDD.ATM.UI.Presenters.ILoginPresenter>(delegate
				{
					return new DDD.ATM.UI.Presenters.LoginPresenter();
				});
		}
	}
}
