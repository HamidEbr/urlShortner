using Data.UrlShortner;
using Repo.UrlShorner.Repository;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Service.UrlShortner
{
    public class UrlShortnerService : IUrlShortnerService
    {
        private IUrlDataRepository _repository;
        private static readonly SemaphoreLocker _locker = new SemaphoreLocker();

        public UrlShortnerService(IUrlDataRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> GenerateShortenURL(string url)
        {
            if (!Helper.IsValidUrl(url))
            {
                throw new ArgumentException("Url is not valid!");
            }
            string token = GenerateToken();
            UrlData urlData = new UrlData()
            {
                Created = DateTime.Now,
                OriginalURL = url,
                Token = token,
                ShortenedURL = token,
                Visits = 0
            };
            await _repository.Save(urlData);
            return urlData.Token;
        }

        /// <summary>
        /// Generate a random token in range of capital or non-capital alphabets and digits
        /// </summary>
        /// <returns></returns>
        private string GenerateToken()
        {
            string urlsafe = string.Empty;
            Enumerable.Range(48, 75)
              .Where(i => i < 58 || i > 64 && i < 91 || i > 96)
              .OrderBy(o => new Random().Next())
              .ToList()
              .ForEach(i => urlsafe += Convert.ToChar(i)); // Store each char into urlsafe
            string token = urlsafe.Substring(new Random().Next(0, urlsafe.Length), new Random().Next(2, 6));
            return token;
        }

        /// <summary>
        /// Get Shorten url using token part with increament visitors counter
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<string> GetShortenUrl(string token)
        {
            string result = string.Empty;
            await _locker.LockAsync(async () =>
            {
                UrlData urlData = await _repository.Get(token);
                if(urlData != null)
                {
                    result = urlData?.OriginalURL;
                    urlData.Visits++;
                    await _repository.Update(urlData);
                }
            });
            return result;
        }
    }
}
