using Android.Speech.Tts;
using Java.Util;
using MobileClient.Droid;
using System.Linq;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeechImplementation))]
namespace MobileClient.Droid
{
    public class TextToSpeechImplementation : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;

        public void Speak(string text)
        {
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(MainActivity.Instance, this);                
            }
            else
            {                
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void OnInit(OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }

        public void Speak(string text, string language)
        {
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(MainActivity.Instance, this);

                speaker.SetLanguage(new Locale(language));
            }
            else
            {
                speaker.SetLanguage(new Locale(language));

                speaker.Speak(toSpeak, QueueMode.Flush, null, null);
            }
        }
    }
}