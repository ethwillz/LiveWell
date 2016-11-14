using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class MainOrSearchHouse : ContentPage
	{
		public MainOrSearchHouse(String residentID, String firstName)
		{
			InitializeComponent();
			title.Text = "Hi, " + firstName;
		}

		public void OnMainButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new Resident());
		}
		public void OnSearchButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new HouseSearchTabbedPage());
		}
	}
}
