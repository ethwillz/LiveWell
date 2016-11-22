using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class MoreTab : ContentPage
	{
		public MoreTab()
		{
			InitializeComponent();
		}

		public void OnMainButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new Resident());
		}
		public void OnLogOutButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new FirstPage());
		}
	}
}