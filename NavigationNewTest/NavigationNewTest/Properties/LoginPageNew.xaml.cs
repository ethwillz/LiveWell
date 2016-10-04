using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public partial class LoginPageNew : ContentPage
	{
		public LoginPageNew()
		{
			InitializeComponent();
		}

		async void OnLoginButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new MainOrSearchHouseNew());
		}
	}
}
