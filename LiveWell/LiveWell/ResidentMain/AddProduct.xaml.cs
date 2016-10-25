using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class AddProduct : ContentPage
    {
        List<ListInformation> lists;
        List<Item> items;
        String name;
        String user;
        int index;

        public AddProduct(List<ListInformation> lists, String name, String user, int index)
        {
            InitializeComponent();

            this.lists = lists;
            this.name = name;
            this.user = user;
            this.index = index;

            populateSuggestions();
        }

        async void populateSuggestions()
        {
            DatabaseGET conn = new DatabaseGET();
            List<ListInformation> suggestions = await conn.getSuggestions(1);

            items = new List<Item>();
            for(int i = 0; i < suggestions.Count; i++)
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
            for(int i = 0; i < foods.Count; i++)
            {
                if (foods[i].name.Equals(item.Text.ToLower()))
                    imageUrl = foods[i].imageUrl;
            }

            DatabasePOST conn2 = new DatabasePOST();
            DatabaseGET conn3 = new DatabaseGET();
            await conn2.postItem("1", item.Text, imageUrl);
            MessagingCenter.Send(this, "newList", await conn3.getLists(1));
            await Navigation.PushModalAsync(new ListDetails(lists, name, user, index));
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
