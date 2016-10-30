using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class MainOrSearchHouse : ContentPage
	{
		public MainOrSearchHouse()
		{
			InitializeComponent();
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
