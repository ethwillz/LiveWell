using System;

using Xamarin.Forms;

namespace Hello
{
    public partial class Audio : ContentPage
    {
        public Audio()
        {
            InitializeComponent();
        }

        public void start(Object sender, EventArgs e)
        {
            Stop.IsEnabled = true;
            Start.IsEnabled = false;

            DependencyService.Get<AudioInterface>().startAudio();

        }

        public void stop(Object sender, EventArgs e)
        {
            Stop.IsEnabled = false;
            Start.IsEnabled = true;

            DependencyService.Get<AudioInterface>().endAudio();
        }
    }
}
