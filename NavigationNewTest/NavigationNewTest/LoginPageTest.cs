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

			// Create Buttons
			var loginButton = new Button() { Text = "Login" };
			loginButton.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new firstPage());
			};

			Content = new StackLayout()
			{
				Children = {
					loginButton,
					_pages
				}
			};
		}
	}
}

