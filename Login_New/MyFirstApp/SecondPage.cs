using System;

using Xamarin.Forms;

namespace MyFirstApp
{
	public class SecondPage : ContentPage
	{
		public SecondPage()
		{
			var btn_PopAsync = new Button
			{
				Text = "PopAsync"
			};
			var btn_PushModalAsync = new Button
			{
				Text = "PushModalAsync"
			};
			var btn_PopModalAsync = new Button
			{
				Text = "PopModalAsync"
			};
			var btn_PopToRootAsync = new Button
			{
				Text = "PopToRootAsync"
			};

			btn_PopAsync.Clicked += async (sender, e) =>
			{
				await Navigation.PopAsync();
			};
			btn_PushModalAsync.Clicked += async (sender, e) =>
			{
				await Navigation.PushModalAsync(new MainView());
			};
			btn_PopModalAsync.Clicked += async (sender, e) =>
			{
				await Navigation.PopToRootAsync();
			};
			btn_PopToRootAsync.Clicked += async (sender, e) =>
			{
				await Navigation.PopToRootAsync();
			};
			Content = new StackLayout
			{
				Children = {
					btn_PopAsync,
					btn_PushModalAsync,
					btn_PopModalAsync,
					btn_PopToRootAsync
				}

			};
			Title = "Second Page";
		}
	}
}

