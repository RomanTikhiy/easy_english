namespace MobileClient
{
    public interface ITextToSpeech
    {
        void Speak(string text);

        void Speak(string text, string language);
    }
}
