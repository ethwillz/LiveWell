using AVFoundation;
using Foundation;
using Hello.iOS;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(AudioImplementation))]
namespace Hello.iOS
{
    public class AudioImplementation : AudioInterface
    {
        AVAudioRecorder recorder;
        NSError error;
        NSUrl url;
        NSDictionary settings;

        public void startAudio()
        {
            initializeAudio();
            string fileName = string.Format("MyFile{0}.wav", DateTime.Now.ToString("yyyMMddHHmmss"));
            string audioFilePath = Path.Combine(Path.GetTempPath(), fileName);

            url = NSUrl.FromFilename(audioFilePath);
            NSObject[] values = new NSObject[]
            {
                NSNumber.FromFloat(44100.0f), //Sample Rate
                NSNumber.FromInt32((int)AudioToolbox.AudioFormatType.LinearPCM), //AVFormat
                NSNumber.FromInt32(2), //Channels
                NSNumber.FromInt32(16), //PCMBitDepth
                NSNumber.FromBoolean(false), //IsBigEndianKey
                NSNumber.FromBoolean(false) //IsFloatKey
            };

            NSObject[] keys = new NSObject[]
            {
                AVAudioSettings.AVSampleRateKey,
                AVAudioSettings.AVFormatIDKey,
                AVAudioSettings.AVNumberOfChannelsKey,
                AVAudioSettings.AVLinearPCMBitDepthKey,
                AVAudioSettings.AVLinearPCMIsBigEndianKey,
                AVAudioSettings.AVLinearPCMIsFloatKey
            };

            //Set Settings with the Values and Keys to create the NSDictionary
            settings = NSDictionary.FromObjectsAndKeys(values, keys);

            //Set recorder parameters
            recorder = AVAudioRecorder.Create(url, new AudioSettings(settings), out error);

            //Set Recorder to Prepare To Record
            recorder.PrepareToRecord();
            recorder.Record();
        }

        public void endAudio()
        {
            recorder.Stop();
            AVAudioPlayer player = new AVAudioPlayer(url, "wav", out error);
            player.PrepareToPlay();
            player.Play();
        }

        public Boolean initializeAudio()
        {
            var audioSession = AVAudioSession.SharedInstance();
            var err = audioSession.SetCategory(AVAudioSessionCategory.PlayAndRecord);
            if (err != null)
            {
                Console.WriteLine("audioSession: {0}", err);
                return false;
            }
            err = audioSession.SetActive(true);
            if (err != null)
            {
                Console.WriteLine("audioSession: {0}", err);
                return false;
            }
            return true;
        }
    }
}
