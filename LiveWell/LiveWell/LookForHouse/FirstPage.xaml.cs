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
		}

		void OnResidentButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Resident"));
		}
		void OnEmployeeButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Employee"));
		}
		void OnOwnerButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Owner"));
		}
	}
}
