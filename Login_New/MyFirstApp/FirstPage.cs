using System;

using Xamarin.Forms;

namespace MyFirstApp
{
	public class MainView : ContentPage
	{
		public MainView()
		{
			var btn_PushAsync = new Button
			{
				Text = "PushAsync"
			};

			btn_PushAsync.Clicked += async (sender, e) =>
			{
				await Navigation.PushAsync(new SecondPage());
			};


			Content = new StackLayout
			{
				Children = {
					btn_PushAsync

				}
			};
			Title = "Navigation Demo";
		}
	}
}

