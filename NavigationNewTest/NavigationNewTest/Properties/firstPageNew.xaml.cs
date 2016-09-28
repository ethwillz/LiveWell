using System;
using Xamarin.Forms;

namespace NavigationNewTest
{
	public partial class firstPageNew : ContentPage
	{
		public firstPageNew()
		{
			InitializeComponent();
		}

		async void OnResidentButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new LoginPage());
		}

		async void OnEmployeeButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new EmployeeLoginNew());
		}
	}
}