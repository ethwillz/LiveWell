using System;
using System.Collections.Generic;
using static LiveWell.ConnectHelpers;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace LiveWell
{
	public partial class HomeTab : ContentPage
	{
		List<QuickViewImage> list;
		Geocoder geoCoder;
		private double userPositionLatitude = 0;
		private double userPositionLongitude = 0;

		public HomeTab()
		{
			geoCoder = new Geocoder();
			InitializeComponent();
			userLocation();

			FilterTab filter = new FilterTab();
			MessagingCenter.Subscribe<FilterTab, String[]>(this, "filterData", (sender, arg) =>
			{
				int price = (int)Convert.ToDouble(arg[0]);
				String accommodationType = arg[1];
				int numRooms = (int)Convert.ToDouble(arg[2]);
				int distance = (int)Convert.ToDouble(arg[3]);

				populateList(price, accommodationType, numRooms, distance);
				title.Text = "Subscribed";
			});
			if (title.Text != "Subscribed")
			{
				populateList(0, "ALL", 0, 1000);
			}
		}

		async void onTap(object sender, ItemTappedEventArgs e)
		{
			DatabasePOST conn2 = new DatabasePOST();

			var index = (quickview.ItemsSource as List<QuickViewImage>).IndexOf(((ListView)sender).SelectedItem as QuickViewImage);
			System.Diagnostics.Debug.WriteLine(index);

			await conn2.postFavoriteAccommodation(list[index].buildingID,1);

			((ListView)sender).SelectedItem = null;
		}

		async void userLocation()
		{
			var locator = CrossGeolocator.Current;
			var userPosition = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
			userPositionLatitude = userPosition.Latitude;
			userPositionLongitude = userPosition.Longitude;
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
				var approximateLocation = await geoCoder.GetPositionsForAddressAsync(addresses[i].address);
				foreach (var position in approximateLocation)
				{
					double distance = CalculateDistance(position.Latitude, position.Longitude, userPositionLatitude, userPositionLongitude);
					if (distance < maxDistance)
					{
						list.Add(new QuickViewImage(addresses[i].imageUrl, addresses[i].address, addresses[i].accommodationType, addresses[i].buildingID));
						await Task.Delay(300);
					}
				}
			}
			quickview.ItemsSource = list;
			quickview.RowHeight = 400;
			title.Text = "Explore " + list.Count + " Accommodations";

		}

		public double CalculateDistance(double positionLatitude, double positionLongitude, double currentLatitude, double currentLongitude)
		{
			double d = Math.Acos(
				(Math.Sin(deg2rad(positionLatitude)) * Math.Sin(deg2rad(currentLatitude))) +
				(Math.Cos(deg2rad(positionLatitude)) * Math.Cos(deg2rad(currentLatitude)))
				* Math.Cos(deg2rad(currentLongitude - positionLongitude)));

			return 6378.137 * d;
		}

		public double deg2rad(double angle)
		{
			return angle * Math.PI / 180;
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
