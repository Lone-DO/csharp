using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RedditViewer
{
    class Controller
    {
        public static void Fetch()
        {
            /** BELOW IS A MODIFIED API GET METHOD SNIPPET*/
            var webRequest = (HttpWebRequest)WebRequest.Create(Data._url);
            webRequest.Method = "GET";  // <-- GET is the default method/verb, but it's here for clarity
            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var reader = new StreamReader(webResponse.GetResponseStream());
            string s = reader.ReadToEnd();
            var arr = JsonConvert.DeserializeObject<JObject>(s);
            Data.Response = arr;
            /* END OF SNIPPET*/

            Parse("articles");
        }
        private static void Parse(string Type)
        {
            var res = Data.Response["data"]["children"];
            int index = 0;
            foreach (var data in res) index += 1; // Incrementing children for length, to calculate last child

            if (index > 0) Data.setAfter(Data.Response["data"]["children"][index - 1]["data"]["id"].Value<string>());
            RenderArticle(res);
        }
        private static void RenderArticle(JToken obj)
        {
            foreach (var data in obj) RedditViewer.Pages.IndexModel.Body += RedditViewer.Model.Article(data);
        }
    }
}