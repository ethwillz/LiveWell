using ModernHttpClient;
using System;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
	public partial class MapTab : ContentPage
	{
		public MapTab()
		{
			InitializeComponent();
			populateList();
		}

		async void populateList()
		{
			DatabaseConnect conn = new DatabaseConnect();
			List<Address> addresses = await conn.getAddress(1);

			List<QuickViewAddress> address = new List<QuickViewAddress>();

			address.Add(new QuickViewAddress(addresses[0].address, "test"));

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
