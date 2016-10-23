using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class EmployeePage : ContentPage
	{
		public EmployeePage()
		{
			InitializeComponent();
		}

		public EmployeePage(String user)
		{
			InitializeComponent();
			userType.Text = user;
		}

		void CreateButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeSignupPage(userType.Text));
		}

		void LoginButtonClicked(object sender, EventArgs args)
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

		void PasswordButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeePasswordResetPage(userType.Text));
		}

		async void HelpButtonClicked(object sender, EventArgs args)
		{
			await DisplayAlert("Contact Information",
				"Our Email Address: LiveWell@iastate.edu" + '\n' + "Our Phone Number: 515-555-5555",
				"Go Back");
		}
	}
}
