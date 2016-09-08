using System;

using Xamarin.Forms;

namespace Hello
{
    public partial class TextSpeech : ContentPage
    {
        public TextSpeech()
        {
            InitializeComponent();
        }

        public void speak(Object sender, EventArgs e)
        {
            String words = sentence.Text;
            DependencyService.Get<TextToSpeechInterface>().toSpeech(words);
        }
    }
}
