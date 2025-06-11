using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradProj.Infrastructure.External_Services.Amazon;
using System.Text.RegularExpressions;
using GradProj.Domain.RepositoryAbs;
using GradProj.Application.ServiceAbs;

namespace GradProj.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TrackedProductController : ControllerBase
    {
        private readonly ITrackedProductsService _trackedProductsService;

        public TrackedProductController(ITrackedProductsService trackedProductsService)
        {
            _trackedProductsService= trackedProductsService;
        }

        [HttpGet("lookup")]
        public async Task<IActionResult> GetProductDetails(string url, Guid userid)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL boş olamaz.");

            try
            {
                var result = await _trackedProductsService.GetProductFromAmazon(url, userid);
                
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
                var result = await _trackedProductsService.GetDiscountInfoAsync(url);
                return Ok(result);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Axesso API hatası:\n{ex.Message}");
            }
        }

    }
}
