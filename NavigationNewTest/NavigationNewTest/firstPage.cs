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

			var label_LiveWell = new Label { Text = "LiveWell", TextColor = Color.FromHex("#fff"), FontSize = 30, HorizontalOptions = LayoutOptions.Center};
			var label_login = new Label { Text = "__________LOG IN__________", TextColor = Color.FromHex("#fff"), FontSize = 30, HorizontalOptions = LayoutOptions.Center};

			// Create Buttons
			var residentButton = new Button() { 
				Text = "LOGIN AS A RESIDENT", 
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				WidthRequest = 300,
				HeightRequest = 70,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand

			};
			residentButton.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new LoginPageTest());
			};

			var employmentButton = new Button() { 
				Text = "LOGIN AS AN EMPLOYEE",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				WidthRequest = 300,
				HeightRequest = 70,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			employmentButton.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new EmployeeLogin());
			};

			Content = new StackLayout()
			{
				Children = {
					label_LiveWell,
					label_login,
					residentButton,
					employmentButton,
					_pages
				}
			};
		}
	}
}

