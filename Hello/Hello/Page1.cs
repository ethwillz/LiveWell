using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace Hello
{
    public class Page1 : ContentPage
    {
        public Page1()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label {
                        Text = "Ethan's app which is a very interesting app which he made in his bedroom so that he could learn how to use Xamarin for possible use in a class project. Which class you may ask. Computer Science 309 is the answer to that one because I know you were just dying to know and that's what I'm taking and I hope we're making an app because I think we could put together a really cool project which I could use in job applications and such.",
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        TextColor = Color.Blue,
                        BackgroundColor = Color.White,
                        FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                        FontAttributes = FontAttributes.Bold
                    },
                    new Button
                    {
                        Text = "Button"
                    }
                }
            };



#if __IOS__
            Padding = new Thickness(0, 20, 0, 0);
#endif
        }
    }
}
