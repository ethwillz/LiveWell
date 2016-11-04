using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class FilterTab : ContentPage
	{
		static int priceFilter;

		public FilterTab()
		{
			InitializeComponent();
		}

		void OnSearchButtonClicked(object sender, EventArgs args)
		{
			priceFilter = (int)Convert.ToDouble(price.Value.ToString());
			MessagingCenter.Send<FilterTab, int>(this, "price", (int)Convert.ToDouble(price.Value.ToString()));

			var masterPage = this.Parent as TabbedPage;
			masterPage.CurrentPage = masterPage.Children[0]; //Go to Home
		}

		public int getDistance()
		{
			return (int)Convert.ToDouble(distance.Value.ToString());
		}

		public int getPrice()
		{
			return priceFilter;
		}

		public String getAccommodationType()
		{
			if (accommodationType.SelectedIndex < 0)
			{ 
				return "Apartment"; 
			}
			else
			{ 
				return "Apartment";
			} //accommodationType.Items[accommodationType.SelectedIndex];
		}

		public int getNumRooms()
		{
			return (int)Convert.ToDouble(numRooms.Value.ToString());
		}
	}
}