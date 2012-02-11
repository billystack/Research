using System;
using System.Windows.Forms;


namespace DDD.ATM.UI.Views
{
	public partial class LoginForm : Form
	{
		public LoginForm()
		{
			InitializeComponent();
			this.RegisterClientEvents();
		}

 
		private void RegisterClientEvents()
		{
			this.cmdLogin.Click += this.cmdLogin_Click;
		}

		private void cmdLogin_Click(object sender, EventArgs e)
		{
			// Presenter
		}
	}
}
