using Data.UrlShortner;
using System.Threading.Tasks;

namespace Repo.UrlShorner.Repository
{
    /// <summary>
    /// Repository For UrlData CRUD
    /// </summary>
    public interface IUrlDataRepository
    {
        /// <summary>
        /// Get UrlData by shorten token
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        Task Save(UrlData student);

        /// <summary>
        /// Insert UrlData
        /// </summary>
        /// <param name="urlData"></param>
        /// <returns></returns>
        Task<UrlData> Get(string token);

        /// <summary>
        /// Update urlData
        /// </summary>
        /// <param name="urlData"></param>
        /// <returns></returns>
        Task Update(UrlData urlData);
    }
}
