using System;
using System.Net;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// using System.Text.Json;
// using System.Text.Json.Serialization;
namespace RedditViewer
{
    public class Default
    {
        static string _uri = "https://www.reddit.com/r/photoshopbattles/hot/.json";
        public static object Fetch()
        {
            // const int POINT_OF_SATISFIED_CURIOSITY = 7;
            JArray arr = new JArray();
            try
            {
                // string uri = "http://www.awardwinnersonly.com/Content/sundance.json";  // <-- this returns formatted json
                var webRequest = (HttpWebRequest)WebRequest.Create(_uri);
                webRequest.Method = "GET";  // <-- GET is the default method/verb, but it's here for clarity
                var webResponse = (HttpWebResponse)webRequest.GetResponse();
                Console.WriteLine(webResponse);
                // if ((webResponse.StatusCode == HttpStatusCode.OK) && (webResponse.ContentLength > 0))
                // {
                //     var reader = new StreamReader(webResponse.GetResponseStream());
                //     string s = reader.ReadToEnd();
                //     arr = JsonConvert.DeserializeObject<JArray>(s);
                //     int i = 1;
                //     string cat;
                //     string film;
                //     string instavid;
                //     string bluray;
                //     string dvd;
                //     string imghtml;
                //     foreach (JObject obj in arr)
                //     {
                //         cat = (string)obj["category"];
                //         film = (string)obj["film"];
                //         instavid = (string)obj["instavid"];
                //         bluray = (string)obj["bluray"];
                //         dvd = (string)obj["dvd"];
                //         imghtml = (string)obj["imghtml"];
                //         MessageBox.Show(string.Format("Object {0} in JSON array: cat == {1}, " +
                //           "film == {2}, instavid == {3}, bluray == {4}, dvd == {5}, imghtml == {6}",
                //              i, cat, film, instavid, bluray, dvd, imghtml));
                //         i++;
                //         if (i > POINT_OF_SATISFIED_CURIOSITY) break;
                //     }
                //     return arr;
                // }
                // else
                // {
                //     //MessageBox.Show("Was fuer ein Schlamassel! Es gab irgendeine Boo-boo!
                //     MessageBox.Show(string.Format("Status code == {0}, Content length == {1}",
                //       webResponse.StatusCode, webResponse.ContentLength));
                // }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return arr;
        }
        // public class Data

        // public Uri Api() 
        // {
        //     public static string _sort = "hot/";
        // public static string _subReddit = $"r/photoshopbattles/{_sort}";
        // public static string _lastArticle;
        // public static string _url = $"https://www.reddit.com/{_subReddit}.json";
        // // https://www.reddit.com/r/photoshopbattles/hot/.json
        // public Uri call = new Uri(_url);

        // // public string Api { get; set; }
        // }
    }
}