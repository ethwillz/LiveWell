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

            var Users = new Label()
            {
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

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

            var Add = new Button()
            {
                Text = "Add"
            };
            

            var bought = new Button()
            {
                Text = "I bought this"
            };
        }
    }
}
