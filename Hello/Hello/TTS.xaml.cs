using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Hello
{
    public partial class TTS : ContentPage
    {
        public TTS()
        {
            InitializeComponent();
        }

        public void convert()
        {
            String words = sentence.Text;
            DependencyService.Get<TextToSpeechInterface>().toSpeech(words);
        }
    }
}
