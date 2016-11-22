using LiveWell;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace LiveWell
{
    public partial class FirstPage : ContentPage
	{
		public FirstPage()
		{
            if(CurrentUser.type == 0)
            {
                Navigation.PushModalAsync(new MyHome());
            }
            if (CurrentUser.type == 1)
            {
                Navigation.PushModalAsync(new EmployeeMain());
            }
            if (CurrentUser.type == 2)
            {
                Navigation.PushModalAsync(new Owner());
            }
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
