using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class FilterTab : ContentPage
	{
		public FilterTab()
		{
			InitializeComponent();
		}

		void OnSearchButtonClicked(object sender, EventArgs args)
		{
			String[] arr = new String[4] { price.Value.ToString(), accommodationType.Items[accommodationType.SelectedIndex], numRooms.Value.ToString(), distance.Value.ToString() };
			MessagingCenter.Send<FilterTab, String[]>(this, "filterData", arr);

			var masterPage = this.Parent as TabbedPage;
			masterPage.CurrentPage = masterPage.Children[0]; //Go to Home
		}
	}
}