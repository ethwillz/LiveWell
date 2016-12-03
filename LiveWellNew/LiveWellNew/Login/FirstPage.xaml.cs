using LiveWellNew;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class FirstPage : ContentPage
	{
		public FirstPage()
		{
			InitializeComponent();
			logo.Source = ImageSource.FromResource("LiveWellNew.LiveWellFullLogo.png");
		}

		async void OnResidentButtonClicked(object sender, EventArgs args)
		{
			Debug.WriteLine("Resident clicked");
			await Navigation.PushModalAsync(new LoginPage("Resident"));
		}
		async void OnEmployeeButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushModalAsync(new LoginPage("Employee"));
		}
		async void OnOwnerButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushModalAsync(new LoginPage("Owner"));
		}
	}
}