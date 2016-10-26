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

		//void OnSearchButtonClicked(object sender, EventArgs args)
		//{
		//	int x = Int32.Parse(price.Text);
		//	String y = accommodationType.Text;
		//	int z = Int32.Parse(numRooms.Text);
		//	int d = Int32.Parse(distance.Text);
		//	Navigation.PushModalAsync(new MapTab(x,y,z,d));
		//}

		void OnSearchButtonClicked(object sender, EventArgs args)
		{
			int x = (int) Convert.ToDouble(price.Value.ToString());
			String y = accommodationType.Items[];
			int z = (int)Convert.ToDouble(numRooms.Value.ToString());
			int d = (int)Convert.ToDouble(distance.Value.ToString());

			System.Diagnostics.Debug.WriteLine(y);

			Navigation.PushModalAsync(new MapTab(x, y, z, d));
		}
	}
}
