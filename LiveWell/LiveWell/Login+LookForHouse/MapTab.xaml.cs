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
			populateList();
			initializeMap();
		}

		async void addPins(String houseAddress)
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
						Label = "LiveWell house",
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
			addPins(xamarinAddress);
		}

		async void initializeMap()
		{
			
			var locator = CrossGeolocator.Current;
			var userPosition = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

			MyMap.MoveToRegion(
			MapSpan.FromCenterAndRadius(
					new Xamarin.Forms.Maps.Position(userPosition.Latitude,userPosition.Longitude), Distance.FromMiles(1.5)));
		}

		async void populateList()
		{
			String accommodationType = "apartment";
			int price = 1200;
			int numRooms = 1000;
			DatabaseGET conn = new DatabaseGET();
			List<Address> addresses = await conn.getAddress(price, accommodationType,numRooms);

			List<QuickViewAddress> address = new List<QuickViewAddress>();
			for (int i = 0; i < addresses.Count; i++)
			{
				address.Add(new QuickViewAddress(addresses[i].address));
				addPins(addresses[i].address);
				await Task.Delay(1000);
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
