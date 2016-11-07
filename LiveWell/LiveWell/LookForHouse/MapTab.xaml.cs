using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System.Threading.Tasks;

namespace LiveWell
{

	public partial class MapTab : ContentPage
	{
		Geocoder geoCoder;
		private double userPositionLatitude = 0;
		private double userPositionLongitude = 0;


		public MapTab()
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

		async void addPins(String houseAddress, String accommodationType)
		{
			var approximateLocation = await geoCoder.GetPositionsForAddressAsync(houseAddress);

			foreach (var position in approximateLocation)
			{
				var pin = new CustomPin
				{
					Pin = new Pin
					{
						Type = PinType.Place,
						Position = new Xamarin.Forms.Maps.Position(position.Latitude, position.Longitude),
						Label = accommodationType,
						Address = houseAddress
					}
				};
				MyMap.CustomPins = new List<CustomPin> { pin };
				MyMap.Pins.Add(pin.Pin);
			}
		}

		async void userLocation()
		{
			var locator = CrossGeolocator.Current;
			var userPosition = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
			userPositionLatitude = userPosition.Latitude;
			userPositionLongitude = userPosition.Longitude;

			MyMap.MoveToRegion(
			MapSpan.FromCenterAndRadius(
					new Xamarin.Forms.Maps.Position(userPositionLatitude, userPositionLongitude), Distance.FromMiles(1.5)));
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

			List<QuickViewAddress> address = new List<QuickViewAddress>();

			MyMap.Pins.Clear();

			for (int i = 0; i < addresses.Count; i++)
			{
				//System.Diagnostics.Debug.WriteLine(CalculateDistance(userPositionLatitude, userPositionLongitude, 10, 11));
				var approximateLocation = await geoCoder.GetPositionsForAddressAsync(addresses[i].address);
				foreach (var position in approximateLocation)
				{
				double distance = CalculateDistance(position.Latitude, position.Longitude, userPositionLatitude, userPositionLongitude);
					if( distance < maxDistance){
						address.Add(new QuickViewAddress(addresses[i].address + ", Distance: " + distance));

						addPins(addresses[i].address, addresses[i].accommodationType);

						await Task.Delay(300);
					}
				}
			}
			quickview.ItemsSource = address;
			quickview.RowHeight = 30;
			title.Text = "Explore " + address.Count + " Accommodations";
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
			return angle*Math.PI/180;
		}

	}


	public class QuickViewAddress
	{
		public QuickViewAddress(String summary)
		{
			this.Summary = summary;
		}

		public String Summary { get; set; }
	}

	public class CustomPin
	{
		public Pin Pin { get; set; }
		public string Id { get; set; }
		public string Url { get; set; }
	}
}
