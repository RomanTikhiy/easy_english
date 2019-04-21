using MobileClient.Abstractions;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MobileClient.Services
{
    public class Translator : ITranslator
    {
        public async Task<string> TranslateAsync(string fromLanguage, string toLanguage, string text)
        {
            var url = String.Format("https://translate.googleapis.com/translate_a/single?ie=UTF-8&client=gtx&sl={0}&tl={1}&dt=t&q={2}", 
                fromLanguage, toLanguage, HttpUtility.UrlEncode(text, Encoding.UTF8));

            try
            {
                using (var webClient = new HttpClient())
                {
                    var result = await webClient.GetStringAsync(url);

                    return result.Substring(4, result.IndexOf("\"", 4, StringComparison.Ordinal) - 4);
                }
            }
            catch (Exception ex)
            {
                return null;                
            }           
        }
    }
}
