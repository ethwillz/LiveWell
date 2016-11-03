using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class FilterTab : ContentPage
	{
		private int priceFilter;

		public FilterTab()
		{
			InitializeComponent();
		}

		void OnSearchButtonClicked(object sender, EventArgs args)
		{
			priceFilter = (int)Convert.ToDouble(price.Value.ToString());
			System.Diagnostics.Debug.WriteLine("Index: " + accommodationType.SelectedIndex);
			System.Diagnostics.Debug.WriteLine("Price: " + priceFilter);

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