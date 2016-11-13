using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class SignupPage : ContentPage
	{
		public SignupPage()
		{
			InitializeComponent();
		}

		public SignupPage(String user)
		{
			InitializeComponent();
			userType.Text = user;
		}

		void BackButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage(userType.Text));
		}

		async void CreateButtonClicked(object sender, EventArgs args)
		{
			DatabasePOST conn = new DatabasePOST();
			await conn.postResidentInfo(firstName.Text, lastName.Text, email.Text, password.Text);
			Navigation.PushModalAsync(new LoginPage(userType.Text));
		}
	}
}
