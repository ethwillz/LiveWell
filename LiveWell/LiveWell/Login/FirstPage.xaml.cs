using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LiveWell
{
    public partial class FirstPage : ContentPage
	{
		public FirstPage()
		{
			InitializeComponent();

            logo.Source = ImageSource.FromResource("LiveWell.LiveWellFullLogo.png");
			//test.Text = LiveWell.Helpers.Settings.GeneralSettings;
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
