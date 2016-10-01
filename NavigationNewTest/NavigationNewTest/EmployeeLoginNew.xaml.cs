using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public partial class EmployeeLoginNew : ContentPage
	{
		public EmployeeLoginNew()
		{
			InitializeComponent();
		}

		async void OnLoginButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new firstPageNew());
		}
	}
}
