using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradProj.Infrastructure.External_Services.Amazon;
using System.Text.RegularExpressions;

namespace GradProj.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AmazonController : ControllerBase
    {
        private readonly AmazonProductService _amazonService;

        public AmazonController(AmazonProductService amazonService)
        {
            _amazonService = amazonService;
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetProductDetails(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL boş olamaz.");

            try
            {
                var result = await _amazonService.GetProductDetailsAsync(url);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Axesso API hatası:\n{ex.Message}");
            }
        }

        [HttpGet("is-discounted")]
        public async Task<IActionResult> GetIsDiscounted(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL boş olamaz.");

            try
            {
                var result = await _amazonService.GetDiscountInfoAsync(url);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Axesso API hatası:\n{ex.Message}");
            }
        }

    }
}
