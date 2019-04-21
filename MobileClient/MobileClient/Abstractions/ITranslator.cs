using System.Threading.Tasks;

namespace MobileClient.Abstractions
{
    public interface ITranslator
    {
        Task<string> TranslateAsync(string fromLanguage, string toLanguage, string text); 
    }
}
