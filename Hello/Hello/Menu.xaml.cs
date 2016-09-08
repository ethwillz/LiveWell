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

        public void texttospeech(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new TTS());
        }

        public void youtube(Object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Youtube());
        }
    }
}
