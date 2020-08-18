using System;
using System.Threading;
using System.Threading.Tasks;

namespace Service.UrlShortner
{
    /// <summary>
    /// In order to lock and unlock solving threadsafe problem in async methods
    /// </summary>
    public class SemaphoreLocker
    {
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        /// <summary>
        /// overloading variant for void methods
        /// </summary>
        /// <param name="worker"></param>
        /// <returns></returns>
        public async Task LockAsync(Func<Task> worker)
        {
            await _semaphore.WaitAsync();
            try
            {
                await worker();
            }
            finally
            {
                _semaphore.Release();
            }
        }

        /// <summary>
        /// overloading variant for non-void methods with return type (generic T)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="worker"></param>
        /// <returns></returns>
        public async Task<T> LockAsync<T>(Func<Task<T>> worker)
        {
            await _semaphore.WaitAsync();

            T result = default;

            try
            {
                result = await worker();
            }
            finally
            {
                _semaphore.Release();
            }

            return result;
        }
    }
}
