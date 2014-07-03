using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Codeplex.Data;


namespace ForvoDownloader
{
    class Forvo
    {
        private WebClient webClient = new WebClient();
        private string apikey = null;
        private const int API_LEN = 32;
        private string apiUrl = "http://apifree.forvo.com";

        private string lang = "en";

        public String Language
        {
            get { return lang; }
            set { lang = value; }
        }

        public string ApiUrl
        {
            get { return apiUrl; }
            set
            {
                if (!Uri.IsWellFormedUriString(value, UriKind.Absolute))
                {
                    throw new ArgumentException("Invalid API URL");
                }
                apiUrl = value;
            }
        }

        public string Apikey
        {
            get { return apikey; }
            set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < API_LEN)
                {
                    throw new ArgumentException("Not a valid apikey");
                }
                apikey = value;
            }
        }

        public Forvo()
        {
            
        }
        public Forvo(string apikey)
        {
            this.Apikey = apikey;
            
        }
        public Dictionary<string, string> GetLanguageList()
        {
            string uri = ApiUrl + "/key/"+Apikey+"/format/json/action/language-list/min-pronunciations/500";
            Console.WriteLine(uri);
            StringBuilder sb = new StringBuilder();
            dynamic jsonResult = DynamicJson.Parse(webClient.DownloadString(uri));

            Dictionary<string, string> languagePair = new Dictionary<string, string>();

            foreach (var language in jsonResult["items"])
            {
                //{"code":"af","en":"Afrikaans"}{"code":"an","en":"Aragonese"}
                sb.Append(language["code"]);
                languagePair.Add(language["en"], language["code"]);
            }

            return languagePair;

        }

        public List<WordPronunciation> GetListWordPronunciations(Word word)
        {
            return GetListWordPronunciations(word.ToString());
        }

        public List<WordPronunciation> GetListWordPronunciations(string word)
        {
            List<WordPronunciation> wordPronunciations = new List<WordPronunciation>();
            string encodedWord =  Uri.EscapeUriString(word);
            string uri = ApiUrl + "/key/" + Apikey + "/format/json/action/word-pronunciations/word/" + encodedWord + "/language/" + Language;
            dynamic jsonResult = DynamicJson.Parse(webClient.DownloadString(uri));

            foreach (var items in jsonResult["items"])
            {
                WordPronunciation addWordPronunciation = new WordPronunciation(id: (int)items["id"], word: items["word"], hits: (int)items["hits"], pathmp3: items["pathmp3"]);
                wordPronunciations.Add(addWordPronunciation);
            }
            return wordPronunciations;
        } 
    }

}
