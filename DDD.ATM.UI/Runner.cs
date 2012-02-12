using System;
using IOCContainer = DDD.ATM.UI.IOC.Container;

namespace DDD.ATM.UI
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			// TODO: Will have application bootstrapping here
			new DDD.ATM.UI.Bootstrapper().Bootstrap();

			var clientSearchFormPresenter = IOCContainer.Instance.Create<DDD.ATM.UI.Presenters.ILoginPresenter>();

			clientSearchFormPresenter.Display();

			// TODO: Will be using model/view presenter pattern here

			// TODO: Must figure out how to wire all view events with presenter event handlers
		}
	}
}
