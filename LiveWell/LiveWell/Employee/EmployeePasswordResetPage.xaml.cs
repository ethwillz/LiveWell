using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class EmployeePasswordResetPage : ContentPage
	{
		public EmployeePasswordResetPage()
		{
			InitializeComponent();
		}

		async void SendPasswordButtonClicked(object sender, EventArgs args)
		{
			await DisplayAlert("Password sent",
				"Your password has been sent",
				"Go Back");
		}

		void BackButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeePage());
		}

	}
}
