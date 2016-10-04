using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		async void OnLoginButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new MainOrSearchHouseNew());
		}
	}
}
