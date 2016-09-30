using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class AddProduct : ContentPage
    {
        public AddProduct()
        {
            InitializeComponent();

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
