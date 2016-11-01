using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class FirstPage : ContentPage
	{
		public FirstPage()
		{
			InitializeComponent();
			btntest.Clicked += OnResidentButtonClicked;

		}

		public void OnResidentButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Resident"));
		}
		public void OnEmployeeButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Employee"));
		}
		public void OnOwnerButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Owner"));
		}
	}
}
