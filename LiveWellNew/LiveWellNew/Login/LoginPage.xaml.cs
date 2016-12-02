using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWellNew
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
			var personalInfo = await conn.getUserInfo(userType.Text, email.Text, password.Text);

			if (personalInfo.Count > 0)
			{
				if (userType.Text == "Resident")
				{
					CurrentUser.ID = Convert.ToInt32(personalInfo[0].residentID);
					CurrentUser.type = 'R';
					//LiveWellNew.Helpers.Settings.GeneralSettings = "" + CurrentUser.type + CurrentUser.ID;
					await Navigation.PushModalAsync(new MainOrSearchHouse());
				}
				else if (userType.Text == "Employee")
				{
					CurrentUser.ID = Convert.ToInt32(personalInfo[0].employeeID);
					CurrentUser.type = 'E';
					//LiveWellNew.Helpers.Settings.GeneralSettings = "" + CurrentUser.type + CurrentUser.ID;
					await Navigation.PushModalAsync(new EmployeeMain());
				}
				else if (userType.Text == "Owner")
				{
					CurrentUser.ID = Convert.ToInt32(personalInfo[0].ownerID);
					CurrentUser.type = 'O';
					//LiveWellNew.Helpers.Settings.GeneralSettings = "" + CurrentUser.type + CurrentUser.ID;
					await Navigation.PushModalAsync(new Owner());
				}
			}

			else {
				errorMessage.Text = "Please type correct email address and password";
			}

		}
	}
}