using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class ListDetails : ContentPage
    {
        List<Product> productList;
        String listID;
        String name;
        String user;
        List<ConnectHelpers.Item> items;

        public ListDetails(String listID, String name, String user)
        {
            InitializeComponent();

            this.listID = listID;
            this.name = name;
            this.user = user;

            listName.Text = name;
            users.Text = user;

            populatePage();
        }

        async void populatePage()
        {
            DatabaseGET conn = new DatabaseGET();
            items = await conn.getProductsOnList(listID);

            productList = new List<Product>();
            for(int i = 0; i < items.Count; i++)
            {
                productList.Add(new Product(items[i].imageUrl, items[i].itemName));
            }

            MessagingCenter.Subscribe<AddProduct, List<ConnectHelpers.Item>>(this, "newList", (sender, refresh) => {
                productList = new List<Product>();
                for (int i = 0; i < refresh.Count; i++)
                {
                    productList.Add(new Product(refresh[i].imageUrl, refresh[i].itemName));
                }
                products.ItemsSource = productList;
            });

            products.ItemsSource = productList;
            products.RowHeight = 60;
            products.IsPullToRefreshEnabled = true;
        }

        public void addClick(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new AddProduct(items, name, user, listID));
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
