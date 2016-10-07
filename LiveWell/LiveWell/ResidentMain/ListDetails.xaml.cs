using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace LiveWell
{
    public partial class ListDetails : ContentPage
    {
        public ListDetails()
        {
            InitializeComponent();

            List<Product> productList = new List<Product>()
            {
                new Product("http://canigivemybaby.com/wp-content/uploads/2011/11/can-i-give-my-baby-skim-milk.jpg", "Skim milk"),
                new Product("https://thumbs.dreamstime.com/x/hamburger-patty-6817492.jpg", "Burgers"),
                new Product("http://img1.nymag.com/imgs/daily/grub/2013/08/07/07-hamburger-bun.w529.h352.2x.jpg", "Burger buns"),
                new Product("http://www.heinzketchup.com/-/media/heinzna/images/heinzketchup/products/hzk_3d_32oz_ketchup-small.ashx?as=0&.jpg&hash=9516F8B71BEAC8D65F95FA07445D7C0C64C6C04D", "Ketchup"),
                new Product("http://juliandance.org/wp-content/uploads/2016/01/RedApple.jpg", "Apples"),
                new Product("http://canigivemybaby.com/wp-content/uploads/2011/11/can-i-give-my-baby-skim-milk.jpg", "Skim milk"),
                new Product("https://thumbs.dreamstime.com/x/hamburger-patty-6817492.jpg", "Burgers"),
                new Product("http://img1.nymag.com/imgs/daily/grub/2013/08/07/07-hamburger-bun.w529.h352.2x.jpg", "Burger buns"),
                new Product("http://www.heinzketchup.com/-/media/heinzna/images/heinzketchup/products/hzk_3d_32oz_ketchup-small.ashx?as=0&.jpg&hash=9516F8B71BEAC8D65F95FA07445D7C0C64C6C04D", "Ketchup"),
                new Product("http://juliandance.org/wp-content/uploads/2016/01/RedApple.jpg", "Apples"),
                new Product("http://canigivemybaby.com/wp-content/uploads/2011/11/can-i-give-my-baby-skim-milk.jpg", "Skim milk"),
                new Product("https://thumbs.dreamstime.com/x/hamburger-patty-6817492.jpg", "Burgers"),
                new Product("http://img1.nymag.com/imgs/daily/grub/2013/08/07/07-hamburger-bun.w529.h352.2x.jpg", "Burger buns"),
                new Product("http://www.heinzketchup.com/-/media/heinzna/images/heinzketchup/products/hzk_3d_32oz_ketchup-small.ashx?as=0&.jpg&hash=9516F8B71BEAC8D65F95FA07445D7C0C64C6C04D", "Ketchup"),
                new Product("http://juliandance.org/wp-content/uploads/2016/01/RedApple.jpg", "Apples"),
            };

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
