using System;
using System.Text.RegularExpressions;


namespace TagCompressor.NetCore
{
    class HtmlCompressor
    {
        public static string Compress(string html)
        {
            string pattern = @"\n+";
            Regex r = new Regex(pattern);
            string compressed = r.Replace(html, "");

            pattern = @"\s+";
            r = new Regex(pattern);
            compressed = r.Replace(compressed, " ");


            return compressed;
        }
    }
}
