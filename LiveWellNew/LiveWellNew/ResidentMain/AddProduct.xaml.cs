using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static LiveWellNew.ConnectHelpers;

namespace LiveWellNew
{
	public partial class AddProduct : ContentPage
	{
		List<ConnectHelpers.Item> lists;
		List<Item> items;
		String name;
		String user;
		String listID;
		int newList = 0;

		public AddProduct(List<ConnectHelpers.Item> lists, String name, String user, String listID)
		{
			InitializeComponent();

			this.lists = lists;
			this.name = name;
			this.user = user;
			this.listID = listID;

			populateSuggestions();
		}

		public AddProduct(String listID)
		{
			InitializeComponent();

			this.listID = listID;
			newList = 1;

			populateSuggestions();
		}

		async void populateSuggestions()
		{
			DatabaseGET conn = new DatabaseGET();
			List<ConnectHelpers.Item> suggestions = await conn.getSuggestions(CurrentUser.ID);

			items = new List<Item>();
			for (int i = 0; i < suggestions.Count; i++)
			{
				items.Add(new Item(suggestions[i].itemName));
			}

			suggestedItems.ItemsSource = items;
		}
		async void add(Object sender, EventArgs e)
		{
			DatabaseGET conn = new DatabaseGET();
			List<Food> foods = await conn.getFoods();

			var imageUrl = "https://firebasestorage.googleapis.com/v0/b/livewell-78cf1.appspot.com/o/question.jpg?alt=media&token=7ac00a49-b7a1-4ce1-b447-31eba31406ea";
			for (int i = 0; i < foods.Count; i++)
			{
				if (foods[i].name.Equals(item.Text.ToLower()))
					imageUrl = foods[i].imageUrl;
			}

			DatabasePOST conn2 = new DatabasePOST();

			if (newList == 0)
			{
				Debug.WriteLine(listID + " " + item.Text + " " + imageUrl);
				await conn2.postItem(listID, item.Text, imageUrl);
				//MessagingCenter.Send(this, "newList", await conn.getLists(1));
				await Navigation.PushModalAsync(new ListDetails(listID, name, user));
			}
			else
			{
				Debug.WriteLine(listID + " " + item.Text + " " + imageUrl);
				await conn2.postItem(listID, item.Text, imageUrl);
				//MessagingCenter.Send(this, "newList", await conn.getLists(1));
				await Navigation.PopModalAsync();
			}
		}

		void onTap(object sender, ItemTappedEventArgs e)
		{
			var index = (suggestedItems.ItemsSource as List<Item>).IndexOf(((ListView)sender).SelectedItem as Item);
			item.Text = items[index].ItemName;
			((ListView)sender).SelectedItem = null;
		}
	}

	public class Item
	{
		public Item(String itemName)
		{
			this.ItemName = itemName;
		}

		public String ItemName { get; set; }
	}
}