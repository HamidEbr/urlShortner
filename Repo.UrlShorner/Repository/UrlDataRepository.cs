using Data.UrlShortner;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Repo.UrlShorner.Repository
{
    /// <summary>
    /// Repository For UrlData CRUD
    /// </summary>
    public class UrlDataRepository : IUrlDataRepository
    {
        private readonly UrlShortnerContext _context;

        public UrlDataRepository(UrlShortnerContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get UrlData by shorten token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async Task<UrlData> Get(string token)
        {
            var list = _context.Set<UrlData>();

            return await list
                .SingleOrDefaultAsync(u => u.ShortenedURL == token);
        }

        /// <summary>
        /// Insert UrlData
        /// </summary>
        /// <param name="urlData"></param>
        /// <returns></returns>
        public async Task Save(UrlData urlData)
        {
            _context.Add(urlData);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update urlData
        /// </summary>
        /// <param name="urlData"></param>
        /// <returns></returns>
        public async Task Update(UrlData urlData)
        {
            _context.Update(urlData);
            await _context.SaveChangesAsync();
        }
    }
}
