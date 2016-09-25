using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class GroceryLists : ContentPage
    {
        public GroceryLists()
        {
            InitializeComponent();

            List<Product> standardProducts = new List<Product>()
            {
                new Product("milkurl", "Skim milk"),
                new Product("cookiesurl", "Chocolate chip cookies"),
                new Product("tomatoesurl", "Tomatoes"),
                new Product("hotdogsurl", "Hot Dogs"),
                new Product("bunsurl", "Hot dog buns"),
                new Product("ketchupurl", "Ketchup")
            };

            //List which will come from database with all the list items and information
            List<ListInfo> lists = new List<ListInfo>()
            {
                new ListInfo("Bathroom stuff", "Ethan W. & Micah B.", standardProducts),
                new ListInfo("Food and such", "Chase W. & Micah B.", standardProducts),
                new ListInfo("Party supplies", "Chris W. & Micah B.", standardProducts),
            };

            allLists.ItemsSource = lists;
            allLists.RowHeight = 60;
        }
    }

    //Product object which stores information for a single product which is on a grocery list
    public class Product
    {
        String url;
        String name;

        public Product(String url, String name)
        {
            this.url = url;
            this.name = name;
        }
    }

    //List class which has all information for a given list
    public class ListInfo
    {
        public ListInfo(String listName, String users, List<Product> products)
        {
            this.ListName = listName;
            this.Users = users;
            this.Products = products;
        }

        public String ListName { get; set; }
        public String Users { get; set; }
        public List<Product> Products { get; set; }
    }
}
