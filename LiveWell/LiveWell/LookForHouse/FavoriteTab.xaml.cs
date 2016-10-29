using System;
using System.Collections.Generic;
using static LiveWell.ConnectHelpers;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class FavoriteTab : ContentPage
	{
		public FavoriteTab()
		{
			InitializeComponent();
			populateList();
		}

		async void populateList()
		{
			List<Address> addresses;
			DatabaseGET conn = new DatabaseGET();
			addresses = await conn.getAddress();


			List<QuickViewImage> address = new List<QuickViewImage>();
			for (int i = 0; i < addresses.Count; i++)
			{
				address.Add(new QuickViewImage(addresses[i].imageUrl, addresses[i].address, addresses[i].accommodationType));
			}
			quickview.ItemsSource = address;
			quickview.RowHeight = 400;
			title.Text = "Favorite " + addresses.Count + " Accommodations";

		}
	}
}
