using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class TestPage : ContentPage
	{
		public TestPage()
		{
			InitializeComponent();
		}
		public void OnLoginButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new MainOrSearchHouse());
		}
	}
}
