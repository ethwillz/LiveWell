using System;

using Xamarin.Forms;

namespace Hello
{
    public partial class Menu : ContentPage
    {
        public Menu()
        {
            InitializeComponent();
        }

        public void calculator(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Calculator());
        }

        public void audio(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Audio());
        }

        public void textspeech(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TextSpeech());
        }

        public void youtube(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Youtube());
        }
    }
}
