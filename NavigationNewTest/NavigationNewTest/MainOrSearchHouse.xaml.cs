using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NavigationNewTest
{
	public partial class MainOrSearchHouse : ContentPage
	{
		public MainOrSearchHouse()
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
