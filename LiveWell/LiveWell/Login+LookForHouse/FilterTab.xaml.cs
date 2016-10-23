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
			int x = Int32.Parse(price.Text);
			String y = accommodationType.Text;
			int z = Int32.Parse(numRooms.Text);
			Navigation.PushModalAsync(new MapTab(x,y,z));
		}
	}
}
