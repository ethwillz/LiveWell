using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class Important : ContentPage
	{
		public Important()
		{
			InitializeComponent();

			List<Notification> notifications = new List<Notification>()
			{
				new Notification("PLACEHOLDER", "TEST"),
			};

			quickview.ItemsSource = notifications;
			quickview.RowHeight = 60;
		}

		public class Notification
		{
			public Notification(String summary, String details)
			{
				this.Summary = summary;
				this.Details = details;
			}

			public String Summary { get; set; }
			public String Details { get; set; }
		}
	}
}