using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class EmployeeMorePage : ContentPage
	{
		public EmployeeMorePage()
		{
			InitializeComponent();
		}

		public void OnLogOutButtonClicked(object sender, EventArgs args)
		{
			//LiveWell.Helpers.Settings.GeneralSettings = "";
			CurrentUser.type = 'N';
			Navigation.PushModalAsync(new FirstPage());
		}
	}
}