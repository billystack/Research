using System;
using System.Windows.Forms;


namespace DDD.ATM.UI.Views
{
	public partial class LoginForm : Form, DDD.ATM.UI.Views.ILoginForm
	{
		public LoginForm()
		{
			InitializeComponent();

			this.RegisterClientEvents();
		}

		public event EventAction OnAttemptLogin;


		private void RegisterClientEvents()
		{
			this.cmdLogin.Click += (s, e) => OnAttemptLogin();
		}


		public void Display(
			DDD.ATM.UI.Presenters.LoginPresenter subject)
		{
			this.OnAttemptLogin += subject.AttemptLogin;
			this.ShowDialog();
		}
	}
}
