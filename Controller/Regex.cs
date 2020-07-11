using System.Text.RegularExpressions;
namespace RedditClientViewer.Data
{
    public class Regex : System.Text.RegularExpressions.Regex
    {
        /**Regex, Pull Title and Src from Body
            "New line [https://imgur.com/kKtnL12](https://imgur.com/kKtnL12)"
            Title = [https://imgur.com/kKtnL12]
            Src = https://imgur.com/kKtnL12
            URL_REGEX Test: https://regex101.com/r/MiGGnF/3
            TITLE_REGEX Test: https://regex101.com/r/MiGGnF/4
        **/
        public static RegexOptions OPTIONS = RegexOptions.Multiline | RegexOptions.IgnoreCase;
        public static string URL_REGEX = @"(ht)(.)+?:(\/){2}?(\w)+.(\w)+(\/)?(\w)+.(\w)+(\/?)(\w?)+(\.?)(\w?)+";
        public static string TITLE_REGEX = @"^.+?(?=\(?\s?http)";
    }
}
