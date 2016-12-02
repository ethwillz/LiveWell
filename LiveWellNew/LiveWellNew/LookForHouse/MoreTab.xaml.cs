using System;
using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class MoreTab : ContentPage
	{
		public MoreTab()
		{
			InitializeComponent();
		}

		public void OnMainButtonClicked(object sender, EventArgs args)
		{
			//Navigation.PushModalAsync(new Resident());
		}
		public void OnLogOutButtonClicked(object sender, EventArgs args)
		{
			//LiveWell.Helpers.Settings.GeneralSettings = "";
			CurrentUser.type = 'N';
			Navigation.PushModalAsync(new FirstPage());
		}
	}
}