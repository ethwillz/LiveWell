using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LiveWell
{
    class CustomGroceryCell :ViewCell
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

            var ProductsList = new ListView()
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
            ProductsList.SetBinding(ListView.ItemsSourceProperty, "Products");

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
