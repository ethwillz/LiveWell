using System;
using System.Collections.Generic;
using static LiveWell.ConnectHelpers;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class HomeTab : ContentPage
	{
		List<QuickViewImage> list;

		public HomeTab()
		{
			InitializeComponent();
			populateList(0, "ALL", 0, 100);
		}

		public HomeTab(int price, String accommodationType, int numRooms, int maxDistance)
		{
			InitializeComponent();
			populateList(price, accommodationType, numRooms, 10);

		}


		async void onTap(object sender, ItemTappedEventArgs e)
		{
			DatabasePOST conn2 = new DatabasePOST();

			var index = (quickview.ItemsSource as List<QuickViewImage>).IndexOf(((ListView)sender).SelectedItem as QuickViewImage);
			System.Diagnostics.Debug.WriteLine(index);
			System.Diagnostics.Debug.WriteLine(list[index].buildingID);

			await conn2.postFavoriteAccommodation(list[index].buildingID,1);

			((ListView)sender).SelectedItem = null;
		}

		async void populateList(int price, String accommodationType, int numRooms, int maxDistance)
		{
			List<Address> addresses;
			DatabaseGET conn = new DatabaseGET();
			if (accommodationType == "ALL")
			{
				addresses = await conn.getAddress();
			}
			else {
				addresses = await conn.getAddress(price, accommodationType, numRooms);
			}

			list = new List<QuickViewImage>();
			for (int i = 0; i < addresses.Count; i++)
			{
				list.Add(new QuickViewImage(addresses[i].imageUrl,addresses[i].address, addresses[i].accommodationType, addresses[i].buildingID));
				//await Task.Delay(300);
			}
			quickview.ItemsSource = list;
			quickview.RowHeight = 400;
			title.Text = "Explore " + addresses.Count + " Accommodations";

		}
	}

	public class QuickViewImage
	{
		public QuickViewImage(String AccommodationImageUrl, String AccommodationAddress, String AccommodationType, int buildingID)
		{
			this.AccommodationImageUrl = AccommodationImageUrl;
			this.AccommodationAddress = AccommodationAddress;
			this.AccommodationType = AccommodationType;
			this.buildingID = buildingID;
		}

		public String AccommodationImageUrl { get; set; }
		public String AccommodationAddress { get; set; }
		public String AccommodationType { get; set; }
		public int buildingID { get; set; }

	}
}
