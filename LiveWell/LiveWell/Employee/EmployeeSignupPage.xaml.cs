using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Employee
{
	public partial class EmployeeSignupPage : ContentPage
	{
		public EmployeeSignupPage()
		{
			InitializeComponent();
		}

		void BackButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeePage());
		}
	}
}
