using System;

using Xamarin.Forms;

namespace Employee
{
	public partial class EmployeePage : ContentPage
	{
		public EmployeePage()
		{
			InitializeComponent();
		}

		void CreateButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeSignupPage());
		}

		void LoginButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeHomePage());
		}

		void PasswordButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeePasswordResetPage());
		}

		async void HelpButtonClicked(object sender, EventArgs args)
		{
			await DisplayAlert("Contact Information",
				"Our Email Address: LiveWell@iastate.edu" +'\n'+"Our Phone Number: 515-555-5555",
				"Go Back");
		}
	}
}
