using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class OwnerHome : ContentPage
	{
		public OwnerHome()
		{
			InitializeComponent();

			logo.Source = ImageSource.FromResource("LiveWell.LiveWellFullLogo.png");

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
