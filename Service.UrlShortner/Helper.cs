using Data.UrlShortner;
using System;

namespace Service.UrlShortner
{
    public static class Helper
    {
        /// <summary>
        /// Check if a url is valid
        /// </summary>
        /// <param name="url">url string</param>
        /// <returns></returns>
        public static bool IsValidUrl(string url)
        {
            bool result = Uri.TryCreate(url, UriKind.Absolute, out Uri uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
            return result;
        }
    }
}
