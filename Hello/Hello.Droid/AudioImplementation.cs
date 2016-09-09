using System;
using Android.Media;
using Hello.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(AudioImplementation))]
namespace Hello.Droid
{
    public class AudioImplementation : AudioInterface
    {
        MediaRecorder recorder = new MediaRecorder();
        String path = "/sdcard/test.3gpp";

        public void startAudio()
        {
            recorder.SetAudioSource(AudioSource.Mic);
            recorder.SetOutputFormat(OutputFormat.ThreeGpp);
            recorder.SetAudioEncoder(AudioEncoder.AmrNb);
            recorder.SetOutputFile(path);
            recorder.Prepare();
            recorder.Start();
        }

        public void endAudio()
        {
            MediaPlayer player = new MediaPlayer();
            recorder.Stop();
            recorder.Reset();
            player.SetDataSource(path);
            player.Prepare();
            player.Start();
        }
    }
}