using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static LiveWell.ConnectHelpers;

namespace LiveWell
{
    public partial class ListDetails : ContentPage
    {
        List<Product> productList;
        List<ListInformation> lists;
        String name;
        String user;
        int index;
        List<ListInformation> refresh;

        public ListDetails(List<ListInformation> lists, String name, String user, int index)
        {
            InitializeComponent();

            this.lists = lists;
            this.name = name;
            this.user = user;
            this.index = index;

            listName.Text = name;
            users.Text = user;

            populatePage(lists);
        }

        void populatePage(List<ListInformation> lists)
        {
            productList = new List<Product>();
            for(int i = 0; i < lists.Count; i++)
            {
                productList.Add(new Product(lists[i].imageUrl, lists[i].itemName));
            }

            MessagingCenter.Subscribe<AddProduct, List<ListInformation>>(this, "newList", (sender, refresh) => {
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
            Navigation.PushModalAsync(new AddProduct(lists, name, user, index));
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
