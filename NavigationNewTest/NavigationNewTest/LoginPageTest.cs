using System;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public class LoginPageTest : ContentPage
	{
		private StackLayout _pages;

		public LoginPageTest()
		{
			_pages = new StackLayout();

			var usernameEntry = new Entry { Placeholder = "Username" };
			var passwordEntry = new Entry
			{
				Placeholder = "Password",
				IsPassword = true
			};

			// Create Buttons
			var loginButton = new Button() { Text = "Login" };
			loginButton.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new firstPage());
			};

			Content = new StackLayout()
			{
				Children = {
					usernameEntry,
					passwordEntry,
					loginButton,
					_pages
				}
			};
		}
	}
}

