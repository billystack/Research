using System;


namespace DDD.ATM.Commands
{
	public class CustomerAttemptingLogin : DDD.ATM.Commands.ICommand
	{
		private readonly string c_userName;
		private readonly string c_password;

		public string UserName { get { return this.c_userName; } }
		public string Password { get { return this.c_password; } }


		public CustomerAttemptingLogin(
			string userName, 
			string password)
        {
			this.c_userName = userName;
			this.c_password = password;
        }
	}
}
