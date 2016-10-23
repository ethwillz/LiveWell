using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class OwnerLoginPage : ContentPage
	{
		public OwnerLoginPage()
		{
			InitializeComponent();
		}
		public void OnLoginButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new Owner());
		}
	}
}
