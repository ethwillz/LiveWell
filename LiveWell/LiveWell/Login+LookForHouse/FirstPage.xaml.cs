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

		public void OnResidentButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new ResidentLoginPage());
		}
		public void OnEmployeeButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeLoginPage());
		}
	}
}
