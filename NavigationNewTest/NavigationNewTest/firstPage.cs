using System;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public class firstPage : ContentPage
	{
		private StackLayout _pages;

		public firstPage()
		{
			_pages = new StackLayout();

			// Create Buttons
			var residentButton = new Button() { Text = "Resident" };
			residentButton.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new LoginPageTest());
			};

			var employmentButton = new Button() { Text = "Employment" };
			employmentButton.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new LoginPageTest());
			};

			Content = new StackLayout()
			{
				Children = {
					residentButton,
					employmentButton,
					_pages
				}
			};
		}
	}
}

