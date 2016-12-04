using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class PropertyInfo : ContentPage
	{
		public PropertyInfo()
		{
			InitializeComponent();

			List<Room> roomList = new List<Room>()
			{
				new Room("PLACEHOLDER", 0),
			};

			rooms.ItemsSource = roomList;
			rooms.RowHeight = 60;
		}

		void onTap(object sender, ItemTappedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
			Navigation.PushModalAsync(new RoomInfo());
		}



	}

	public class Room
	{
		public Room(String roomNumber, int residents)
		{
			this.RoomNumber = roomNumber;
			this.Residents = residents;
		}

		public String RoomNumber { get; set; }
		public int Residents { get; set; }
	}
}