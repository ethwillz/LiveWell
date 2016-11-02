using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class FilterTab : ContentPage
	{
		public FilterTab()
		{
			InitializeComponent();
		}

		void OnSearchButtonClicked(object sender, EventArgs args)
		{
			int x = (int) Convert.ToDouble(price.Value.ToString());
			String y = accommodationType.Items[accommodationType.SelectedIndex];
			int z = (int)Convert.ToDouble(numRooms.Value.ToString());
			int d = (int)Convert.ToDouble(distance.Value.ToString());

			System.Diagnostics.Debug.WriteLine(y);

			//var masterPage = this.Parent as TabbedPage;
			//HomeTab map = new HomeTab(x,y,z,d);
			//masterPage.CurrentPage = masterPage.Children[0]; //Go to Home

			Navigation.PushModalAsync(new MapTab(x, y, z, d));
		}
	}
}