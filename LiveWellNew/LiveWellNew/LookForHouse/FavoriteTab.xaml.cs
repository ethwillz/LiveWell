using System;
using System.Collections.Generic;
using static LiveWellNew.ConnectHelpers;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace LiveWellNew
{
	public partial class FavoriteTab : ContentPage
	{
		List<QuickViewImage> list;

		public FavoriteTab()
		{
				InitializeComponent();
				populateList();
		}

		async void onTap(object sender, ItemTappedEventArgs e)
		{
			DatabasePOST conn2 = new DatabasePOST();

			var index = (quickview.ItemsSource as List<QuickViewImage>).IndexOf(((ListView)sender).SelectedItem as QuickViewImage);
			System.Diagnostics.Debug.WriteLine(index);
			System.Diagnostics.Debug.WriteLine(list[index].buildingID);

			await conn2.postFavoriteAccommodation(list[index].buildingID, 0);

			((ListView)sender).SelectedItem = null;
			populateList();
		}

		async void populateList()
		{
			List<Address> addresses;
			DatabaseGET conn = new DatabaseGET();
			addresses = await conn.getFavorite();

			list = new List<QuickViewImage>();

			for (int i = 0; i < addresses.Count; i++)
			{
				list.Add(new QuickViewImage(addresses[i].imageUrl, addresses[i].address, addresses[i].accommodationType, addresses[i].buildingID, addresses[i].price, addresses[i].numRooms));
			}
			quickview.ItemsSource = list;
			quickview.RowHeight = 400;
			title.Text = "Favorite " + list.Count + " Accommodations";
		}

	}
}