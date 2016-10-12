using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class OwnerMore : ContentPage
	{
		public OwnerMore()
		{
			InitializeComponent();

			List<Page> pages = new List<Page>()
			{
				new Page("Add Property"),
				new Page("Maintenance")
			};

			otherPages.ItemsSource = pages;
			otherPages.RowHeight = 60;
		}

		public void onTap(object sender, EventArgs e)
		{
			((ListView)sender).SelectedItem = null;
			Navigation.PushModalAsync(new AddProperty());
		}

		public class Page
		{
			public Page(String page)
			{
				this.PageName = page;
			}

			public string PageName { get; set; }
		}
	}
}
