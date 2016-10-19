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

        public AddProduct(List<ListInformation> lists)
        {
            InitializeComponent();

            this.lists = lists;

            List<Item> items = new List<Item>()
            {
                new Item("Pears", "Bought approximately every two weeks"),
                new Item("Chips", "Usually bought on weekly schedule"),
                new Item("Granola bars", "Bought three times this month"),
                new Item("Greek yogurt", "You haven't bought for awhile"),
                new Item("Pears", "Bought approximately every two weeks"),
                new Item("Chips", "Usually bought on weekly schedule"),
                new Item("Granola bars", "Bought three times this month"),
                new Item("Greek yogurt", "You haven't bought for awhile"),
                new Item("Pears", "Bought approximately every two weeks"),
                new Item("Chips", "Usually bought on weekly schedule"),
                new Item("Granola bars", "Bought three times this month"),
                new Item("Greek yogurt", "You haven't bought for awhile"),
            };

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
            await conn2.postItem("1", item.Text, imageUrl);
        }
    }

    public class Item
    {
        public Item(String itemName, String reason)
        {
            this.ItemName = itemName;
            this.Reason = reason;
        }

        public String ItemName { get; set; }
        public String Reason { get; set; }
    }
}
