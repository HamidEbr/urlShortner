using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.UrlShortner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UrlShornerController : ControllerBase
    {
        private readonly ILogger<UrlShornerController> _logger;

        public UrlShornerController(ILogger<UrlShornerController> logger)
        {
            _logger = logger;
        }
    }
}
