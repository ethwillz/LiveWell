using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class EmployeeSignupPage : ContentPage
	{
		public EmployeeSignupPage()
		{
			InitializeComponent();
		}

		public EmployeeSignupPage(String user)
		{
			InitializeComponent();
			userType.Text = user;
		}

		void BackButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeePage(userType.Text));
		}
	}
}
