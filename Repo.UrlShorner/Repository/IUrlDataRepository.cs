using Data.UrlShortner;
using System.Threading.Tasks;

namespace Repo.UrlShorner.Repository
{
    public interface IUrlDataRepository
    {
        Task Save(UrlData student);
        UrlData Get(string shortenUrl);
    }
}
