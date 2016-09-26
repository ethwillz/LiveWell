using System;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public class MainOrSearchHouse : ContentPage
	{
		private StackLayout _pages;

		public MainOrSearchHouse()
		{
			_pages = new StackLayout();

			var label_afterlogin = new Label { Text = "Hi, USERNAME", TextColor = Color.FromHex("#fff"), FontSize = 30, HorizontalOptions = LayoutOptions.Center };

			// Create Buttons
			var btn1 = new Button() { 
				Text = "Have a house",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				WidthRequest = 250,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			var image_withRoommates = new Image { Aspect = Aspect.AspectFit };
			image_withRoommates.Source = ImageSource.FromFile("havehouse.jpg");

			btn1.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new MainPageDemo());
			};

			var btn2 = new Button() { 
				Text = "Look for a house",
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 1,
				WidthRequest = 250,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.CenterAndExpand};
			
			btn2.Clicked += async (object sender, EventArgs e) =>
			{
				await this.Navigation.PushAsync(new TabbedPageTest());
			};


			Content = new StackLayout()
			{
				Children = {
					label_afterlogin,
					image_withRoommates,
					btn1,
					btn2,
					_pages
				}
			};
		}
	}
}

