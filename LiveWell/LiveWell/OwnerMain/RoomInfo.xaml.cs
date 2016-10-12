using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
	public partial class RoomInfo : ContentPage
	{
		public RoomInfo()
		{
			InitializeComponent();


			List<ListInfo> lists = new List<ListInfo>()
			{
				new ListInfo("PLACEHOLDER", "TEST"),
			};

			allLists.ItemsSource = lists;
			allLists.RowHeight = 60;

		}
	}
}
