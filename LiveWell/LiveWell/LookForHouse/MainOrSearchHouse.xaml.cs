using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
	public partial class MainOrSearchHouse : ContentPage
	{
		public MainOrSearchHouse()
		{
			InitializeComponent();

            logo.Source = ImageSource.FromResource("LiveWell.LiveWellFullLogo.png");

            getFirstName();
		}

        async void getFirstName()
        {
            DatabaseGET conn = new DatabaseGET();
            Debug.WriteLine(CurrentUser.ID);
            List<ResidentInfo> info = await conn.getResidentInfo(CurrentUser.ID);
            for(int i = 0; i < info.Count; i++)
            {
				if (Convert.ToInt32(info[i].residentID) == CurrentUser.ID)
				{
					title.Text = "Hi, " + info[i].firstName + "!";
				}
            }
        }

		public void OnMainButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new Resident());
		}
		public void OnSearchButtonClicked(object sender, EventArgs args)
		{
			Navigation.PushModalAsync(new HouseSearchTabbedPage());
		}
	}
}
