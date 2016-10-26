using System;
using System.Collections.Generic;
using static LiveWell.ConnectHelpers;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class HomeTab : ContentPage
	{
		public HomeTab()
		{
			InitializeComponent();
			populateList(0, "ALL", 0, 100);
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

			List<QuickViewImage> address = new List<QuickViewImage>();
			for (int i = 0; i < addresses.Count; i++)
			{
				address.Add(new QuickViewImage(addresses[i].imageUrl,addresses[i].address, addresses[i].accommodationType));
				//await Task.Delay(300);
			}
			quickview.ItemsSource = address;
			quickview.RowHeight = 400;
			title.Text = "Explore " + addresses.Count + " Apartments";

		}
	}

	public class QuickViewImage
	{
		public QuickViewImage(String AccommodationImageUrl, String AccommodationAddress, String AccommodationType)
		{
			this.AccommodationImageUrl = AccommodationImageUrl;
			this.AccommodationAddress = AccommodationAddress;
			this.AccommodationType = AccommodationType;
		}

		public String AccommodationImageUrl { get; set; }
		public String AccommodationAddress { get; set; }
		public String AccommodationType { get; set; }

	}
}
