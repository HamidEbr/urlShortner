using System.Threading.Tasks;

namespace Service.UrlShortner
{
    /// <summary>
    /// Main Service for Generate short link or redirect to a short url
    /// </summary>
    public interface IUrlShortnerService
    {
        /// <summary>
        /// Generate a short link from a url
        /// </summary>
        /// <param name="url">Url string</param>
        /// <returns></returns>
        Task<string> GenerateShortenURL(string url);
        
        /// <summary>
        /// Get original url using short url token part
        /// </summary>
        /// <param name="token">Token part</param>
        /// <returns></returns>
        Task<string> GetShortenUrl(string token);
    }
}
