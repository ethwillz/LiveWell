using System;

namespace Hello
{
    public interface AudioInterface
    {
        void startAudio();
        void endAudio();
    }

    public interface TextToSpeechInterface
    {
        void toSpeech(String sentence);
    }
}
