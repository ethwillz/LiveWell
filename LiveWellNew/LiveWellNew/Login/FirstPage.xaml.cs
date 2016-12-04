using LiveWellNew;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class FirstPage : ContentPage
	{
		public FirstPage()
		{
			String loggedInAs = LiveWellNew.Helpers.Settings.GeneralSettings;
			if (loggedInAs != "")
			{
				CurrentUser.type = loggedInAs[0];
				CurrentUser.ID = Convert.ToInt32(loggedInAs.Substring(1));
			}

			if (CurrentUser.type == 'R')
			{
				Navigation.PushModalAsync(new MainOrSearchHouse());
			}
			if (CurrentUser.type == 'E')
			{
				Navigation.PushModalAsync(new EmployeeMain());
			}
			if (CurrentUser.type == 'O')
			{
				Navigation.PushModalAsync(new Owner());
			}
			InitializeComponent();
			logo.Source = ImageSource.FromResource("LiveWellNew.LiveWellFullLogo.png");
		}

		void OnResidentButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Resident"));
		}
		void OnEmployeeButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Employee"));
		}
		void OnOwnerButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new LoginPage("Owner"));
		}
	}
}