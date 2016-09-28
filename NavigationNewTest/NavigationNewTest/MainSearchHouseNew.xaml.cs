using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public partial class MainOrSearchHouseNew : ContentPage
	{
		public MainOrSearchHouseNew()
		{
			InitializeComponent();
		}

		async void OnMainClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new MainPageDemo());
		}
		async void OnSearchButtonClicked(object sender, EventArgs args)
		{
			await Navigation.PushAsync(new TabbedPageTest());
		}
	}
}
