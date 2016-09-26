using System;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public class MainPageDemo : ContentPage
	{
		private StackLayout _pages;

		public MainPageDemo()
		{
			_pages = new StackLayout();

			var label_MainPage = new Label { Text = "Main Page", TextColor = Color.FromHex("#fff"), FontSize = 30, HorizontalOptions = LayoutOptions.Center };

			Content = new StackLayout()
			{
				Children = {
					label_MainPage,
					_pages
				}
			};
		}
	}
}

