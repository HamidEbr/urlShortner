using Data.UrlShortner;
using System.Linq;
using System.Threading.Tasks;

namespace Repo.UrlShorner.Repository
{
    public class UrlDataRepository : IUrlDataRepository
    {
        private UrlShortnerContext _context;

        public UrlDataRepository(UrlShortnerContext context)
        {
            _context = context;
        }

        public UrlData Get(string shortenUrl)
        {
            return _context.Set<UrlData>().SingleOrDefault(u => u.ShortenedURL == shortenUrl);
        }

        public async Task Save(UrlData urlData)
        {
            _context.Add(urlData);
            await _context.SaveChangesAsync();
        }
    }
}
