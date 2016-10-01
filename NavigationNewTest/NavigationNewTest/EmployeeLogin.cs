using System;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public class EmployeeLogin : ContentPage
	{
		private StackLayout _pages;

		public EmployeeLogin()
		{
			_pages = new StackLayout();

			var label_EmployeeLogin = new Label { Text = "Zi is working on this", TextColor = Color.FromHex("#fff"), FontSize = 30, HorizontalOptions = LayoutOptions.Center };
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
				await this.Navigation.PushAsync(new firstPageNew());
			};

			Content = new StackLayout()
			{
				Children = {
					label_EmployeeLogin,
					usernameEntry,
					passwordEntry,
					loginButton,
					_pages
				}
			};
		}
	}
}

