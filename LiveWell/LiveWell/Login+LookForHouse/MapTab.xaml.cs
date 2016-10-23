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

		public MapTab()
		{
			geoCoder = new Geocoder();
			InitializeComponent();
			populateList(0,"ALL",0);
			userLocation();
		}

		public MapTab(int price, String accommodationType, int numRooms)
		{
			geoCoder = new Geocoder();
			InitializeComponent();
			populateList(price, accommodationType, numRooms);
			userLocation();
		}


		async void addPins(String houseAddress, String accommodationType)
		{
			var approximateLocation = await geoCoder.GetPositionsForAddressAsync(houseAddress);

			foreach (var position in approximateLocation)
			{
				geocodedOutputLabel.Text = position.Latitude + ", " + position.Longitude + "\n";

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

		async void OnTestButtonClicked(object sender, EventArgs args)
		{
			var xamarinAddress = inputEntry.Text;
			addPins(xamarinAddress, "Apartment");
		}

		async void userLocation()
		{
			
			var locator = CrossGeolocator.Current;
			var userPosition = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

			MyMap.MoveToRegion(
			MapSpan.FromCenterAndRadius(
					new Xamarin.Forms.Maps.Position(userPosition.Latitude,userPosition.Longitude), Distance.FromMiles(1.5)));
		}

		async void populateList(int price, String accommodationType, int numRooms)
		{
			//int price = 700;
			//String accommodationType = "Apartment";
			//int numRooms = 3;

			List<Address> addresses;
			DatabaseGET conn = new DatabaseGET();
			if (accommodationType == "ALL"){
				addresses = await conn.getAddress();
			}
			else {
				addresses = await conn.getAddress(price, accommodationType, numRooms);
			}

			List<QuickViewAddress> address = new List<QuickViewAddress>();
			for (int i = 0; i < addresses.Count; i++)
			{
				address.Add(new QuickViewAddress(addresses[i].address));
				addPins(addresses[i].address,addresses[i].accommodationType);
				await Task.Delay(600);
			}

			quickview.ItemsSource = address;
			quickview.RowHeight = 30;

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
