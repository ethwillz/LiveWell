using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            List<List> lists = new List<List>()
            {
                new List("Bathroom stuff", "Ethan W. & Micah B.", standardProducts),
                new List("Food and such", "Chase W. & Micah B.", standardProducts),
                new List("Party supplies", "Chris W. & Micah B.", standardProducts),
            };

            //ListView which will display all of the lists and the information within them
            ListView allLists = new ListView
            {
                ItemsSource = lists,
                ItemTemplate = new DataTemplate(typeof(CustomGroceryCell))
            };

            //Sets content to the listview of all the lists and their information
            Content = allLists;
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
    public class List
    {
        String listName;
        String users;
        List<Product> products;

        public List(String listName, String users, List<Product> products)
        {
            this.listName = listName;
            this.users = users;
            this.products = products;
        }
    }

    //Custom listview cell which shows everything in a list in a well organzed format
    public class CustomGroceryCell : ViewCell
    {
        public CustomGroceryCell()
        {
            var ListName = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            ListName.SetBinding(Label.TextProperty, "ListName", BindingMode.Default);

            var Users = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };
            Users.SetBinding(Label.TextProperty, "Users", BindingMode.Default);

            var Products = new ListView()
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    Image image = new Image();
                    image.SetBinding(Image.SourceProperty, "url");

                    Label name = new Label();
                    name.SetBinding(Label.TextProperty, "name");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Orientation = StackOrientation.Horizontal,
                            Children = {
                                image,
                                name
                            }

                        }
                    };
                })
            };

            var Add = new Button()
            {
                Text = "Add"
            };
            //Add.Clicked += addClicked;
            Add.SetBinding(Button.CommandProperty, "commandAddButton", BindingMode.Default);

            var bought = new Button()
            {
                Text = "I bought this"
            };
        }
    }
}
