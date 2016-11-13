using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
		}

		public LoginPage(String user)
		{
			InitializeComponent();
			userType.Text = user;
		}

		void CreateButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new SignupPage(userType.Text));
		}

		async void LoginButtonClicked(object sender, EventArgs args)
		{
			DatabaseGET conn = new DatabaseGET();
			var personalInfo = await conn.getResidentInfo(email.Text, password.Text);

			if (personalInfo.Count > 0)
			{
				if (userType.Text == "Resident")
				{
					Navigation.PushModalAsync(new MainOrSearchHouse());
				}
				else if (userType.Text == "Employee")
				{
					Navigation.PushModalAsync(new EmployeeHomePage());
				}
				else if (userType.Text == "Owner")
				{
					Navigation.PushModalAsync(new Owner());
				}
			}

			else {
				errorMessage.Text = "Please type correct email address and password"; 
			}

		}

		void PasswordButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new PasswordResetPage(userType.Text));
		}

		async void HelpButtonClicked(object sender, EventArgs args)
		{
			await DisplayAlert("Contact Information",
				"Our Email Address: LiveWell@iastate.edu" + '\n' + "Our Phone Number: 515-555-5555",
				"Go Back");
		}
	}
}
