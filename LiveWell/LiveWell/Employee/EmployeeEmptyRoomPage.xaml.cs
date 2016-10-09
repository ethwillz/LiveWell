using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Employee
{
	public partial class EmployeeEmptyRoomPage : ContentPage
	{
		public EmployeeEmptyRoomPage()
		{
			InitializeComponent();
		}

		void HomeButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeHomePage());
		}

		void HistoryButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeHistoryPage());
		}

		void MaintenanceButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeMaintenancePage());
		}

		void EmptyRoomButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new EmployeeEmptyRoomPage());
		}
	}
}
