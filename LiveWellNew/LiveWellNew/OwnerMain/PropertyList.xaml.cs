using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWellNew
{
	public partial class PropertyList : ContentPage
	{
		public PropertyList()
		{
			InitializeComponent();

			List<ListInfo> lists = new List<ListInfo>()
			{
				new ListInfo("PLACEHOLDER", "TEST"),
			};

			allLists.ItemsSource = lists;
			allLists.RowHeight = 60;


		}

		void onTap(object sender, ItemTappedEventArgs e)
		{
			((ListView)sender).SelectedItem = null;
			Navigation.PushModalAsync(new PropertyInfo());
		}

		public class ListInfo
		{
			public ListInfo(String listName, String users)
			{
				this.ListName = listName;
				this.Users = users; ;
			}

			public String ListName { get; set; }
			public String Users { get; set; }
		}
	}
}