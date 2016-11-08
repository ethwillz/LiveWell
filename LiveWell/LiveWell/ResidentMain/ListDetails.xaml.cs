using LiveWell.ResidentMain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Debug.WriteLine(listID);
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

        async void boughtClick(object sender, EventArgs e)
        {
            if (bought.Text.Equals(""))
            {
                await DisplayAlert("Error", "Please specify amount you bought for", "Okay");
            }
            else
            {
                //gets residents on the list
                //adds split balance to amount of roommate who clicks button
                //adds notification for user letting them know list is bought
                //deleted list from database, keeps items for suggestion purposes
                DatabaseGET conn = new DatabaseGET();
                List<ListInformation> list = await conn.getLists(listID);
                List<String> roommateIDs = new List<string>();
                if(list[0].residentID1 != null && !list[0].residentID1.Equals("1"))
                {
                    roommateIDs.Add(list[0].residentID1);
                }
                if (list[0].residentID2 != null && !list[0].residentID2.Equals("1"))
                {
                    roommateIDs.Add(list[0].residentID2);
                }
                if (list[0].residentID3 != null && !list[0].residentID3.Equals("1"))
                {
                    roommateIDs.Add(list[0].residentID3);
                }
                if (list[0].residentID4 != null && !list[0].residentID4.Equals("1"))
                {
                    roommateIDs.Add(list[0].residentID4);
                }
                String amount = (Convert.ToDouble(bought.Text)/(roommateIDs.Count+1)).ToString();
                DatabasePOST conn2 = new DatabasePOST();
                await conn2.chargeAllAndNotify(amount, "1", roommateIDs, listID, listName.Text);
                NotificationHandler notifications = new NotificationHandler();
                notifications.send(amount, "1", roommateIDs, listID, listName.Text);
            }
        }

        protected override bool OnBackButtonPressed()
        {
            Navigation.PushModalAsync(new Resident());
            return true;
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
