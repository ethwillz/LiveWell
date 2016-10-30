using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class EmployeeLoginPage : ContentPage
	{
		public EmployeeLoginPage()
		{
			InitializeComponent();
		}

		async void OnLoginButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new FirstPage());
		}
	}
}
