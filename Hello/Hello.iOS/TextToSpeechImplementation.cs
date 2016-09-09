using AVFoundation;
using Hello.iOS;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeechImplementation))]
namespace Hello.iOS
{
    class TextToSpeechImplementation : TextToSpeechInterface
    {
        public void toSpeech(String sentence)
        {
            var speechSythensizer = new AVSpeechSynthesizer();

            var speechUtterance = new AVSpeechUtterance(sentence)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSythensizer.SpeakUtterance(speechUtterance);
        }
    }
}
