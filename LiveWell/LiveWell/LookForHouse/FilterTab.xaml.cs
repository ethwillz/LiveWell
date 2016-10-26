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
			//int x = Int32.Parse(price.Value.ToString());
			//String y = "Apartment";//accommodationType.Items[];
			//int z = Int32.Parse(numRooms.Value.ToString());
			//int d = Int32.Parse(distance.Value.ToString());
			int x = 0;
			int d = 0;
			int z = 0;
			String y = "Apartment";
			Navigation.PushModalAsync(new MapTab(x, y, z, d));
		}
	}
}
