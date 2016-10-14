using System;
using System.Collections.Generic;

using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class ListDetails : ContentPage
    {
        List<Product> productList;

        public ListDetails(List<ListInformation> lists, String name, String user)
        {
            InitializeComponent();

            listName.Text = name;
            users.Text = user;

            populatePage(lists);
        }

        async void populatePage(List<ListInformation> lists)
        {
            productList = new List<Product>();
            for(int i = 0; i < lists.Count; i++)
            {
                productList.Add(new Product(lists[i].itemName, lists[i].imageUrl));
            }

            products.ItemsSource = productList;
            products.RowHeight = 60;
        }

        public void addClick(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddProduct());
        }

        public void boughtClick(object sender, EventArgs e)
        {

        }
    }

    //Product object whcich has an image (which is assigned algorithmically upon addition to list) and a name
    public class Product
    {
        public Product(String productImageUrl, String productName)
        {
            this.ProductImageUrl = productImageUrl;
            this.ProductName = productName;
        }

        public String ProductImageUrl { get; set; }
        public String ProductName { get; set; }
    }
}
