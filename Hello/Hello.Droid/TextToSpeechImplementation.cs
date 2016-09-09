using Android.Speech.Tts;
using Hello.Droid;
using System.Collections.Generic;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace Hello.Droid
{
    class TextToSpeechImplementation : Java.Lang.Object, TextToSpeechInterface, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public TextToSpeechImplementation() { }

        public void toSpeech(string text)
        {
            var ctx = Forms.Context; // useful for many Android SDK features
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(ctx, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
        }

        #region IOnInitListener implementation
        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
        }
        #endregion
    }
}