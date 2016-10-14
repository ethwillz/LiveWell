using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;
using Xamarin.Forms.Maps;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;


namespace LiveWell
{

	public partial class MapTab : ContentPage
	{
		public MapTab()
		{
			InitializeComponent();
			populateList();
			setLocation();
		}

		async void setLocation()
		{
			var locator = CrossGeolocator.Current;
			var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

			MyMap.MoveToRegion(
			MapSpan.FromCenterAndRadius(
					new Xamarin.Forms.Maps.Position(position.Latitude,position.Longitude), Distance.FromMiles(1)));
		}

		async void populateList()
		{
			DatabaseConnect conn = new DatabaseConnect();
			List<Address> addresses = await conn.getAddress(1);

			List<QuickViewAddress> address = new List<QuickViewAddress>();
			for (int i = 0; i < addresses.Count; i++)
			{
				address.Add(new QuickViewAddress(addresses[i].address, "TEST: Data from database"));
			}
			quickview.ItemsSource = address;
			quickview.RowHeight = 60;

		}


	}

	public class QuickViewAddress
	{
		public QuickViewAddress(String summary, String details)
		{
			this.Summary = summary;
			this.Details = details;
		}

		public String Summary { get; set; }
		public String Details { get; set; }
	  }
}
