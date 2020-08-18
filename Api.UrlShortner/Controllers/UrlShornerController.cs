using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.UrlShortner;
using System.Threading.Tasks;
using UrlShortnerApi.Models;

namespace Api.UrlShortner.Controllers
{
    [ApiController]
    [Route("api/[action]")]
    public class UrlShornerController : ControllerBase
    {
        private readonly ILogger<UrlShornerController> _logger;
        private readonly IUrlShortnerService _urlShortnerService;

        public UrlShornerController(ILogger<UrlShornerController> logger, IUrlShortnerService urlShortnerService)
        {
            _logger = logger;
            _urlShortnerService = urlShortnerService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateShortenURLAsync([FromBody] GenerateShortenUrlViewModel originalURL)
        {
            string token = await _urlShortnerService.GenerateShortenURL(originalURL.originalUrl);
            return Ok(token);
        }

        // Our Redirect route
        [HttpGet, Route("/{token}")]
        public async Task<IActionResult> RedirectToOriginalUrlAsync([FromRoute] string token)
        {
            string shortenUrl = await _urlShortnerService.GetShortenUrl(token.ToString());
            //shortenUrl = "http://google.com";
            if (string.IsNullOrWhiteSpace(shortenUrl))
            {
                return NotFound(token);
            }
            return Redirect(shortenUrl);
        }
    }
}
