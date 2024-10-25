using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UniversalCodeHelper.Helpers
{
    internal class TranslateApiController
    {
        public async Task<TranslationResponse> TranslateAsync(string textToConvert, string langCode)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("x-apihub-key", "c9LEdQywgMCFZ8Wc0FoAPaxSyvejL-lTM6RpcFEWbIBEUIKV4o");
                client.Headers.Add("x-apihub-host", "Translate.allthingsdev.co");
                client.Headers.Add("x-apihub-endpoint", "3f4ee5f4-f67c-4c5a-9375-635d8b514026");
                client.Headers.Add("Content-Type", "application/json");
                client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.3");

                var requestBody = new
                {
                    input = textToConvert
                };

                string jsonBody = JsonConvert.SerializeObject(requestBody);

                try
                {
                    string result = client.UploadString("https://Translate.proxy-production.allthingsdev.co/translate?translated_from=en&translated_to=" + langCode, jsonBody);
                    TranslationResponse translationResponse = JsonConvert.DeserializeObject<TranslationResponse>(result);
                    return translationResponse;
                }
                catch (WebException webEx)
                {
                    string errorDetails = new System.IO.StreamReader(webEx.Response.GetResponseStream()).ReadToEnd();
                    return null;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }

        }
    }
    public class TranslationResponse
    {
        public Guid Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public List<string> Input { get; set; }
        public string CorrectedText { get; set; }
        public List<string> Translation { get; set; }
        public List<string> Engines { get; set; }
        public LanguageDetection LanguageDetection { get; set; }
        public object ContextResults { get; set; }
        public bool Truncated { get; set; }
        public int TimeTaken { get; set; }
    }

    public class LanguageDetection
    {
        public string DetectedLanguage { get; set; }
        public bool IsDirectionChanged { get; set; }
        public string OriginalDirection { get; set; }
        public int OriginalDirectionContextMatches { get; set; }
        public int ChangedDirectionContextMatches { get; set; }
        public int TimeTaken { get; set; }
    }

}
