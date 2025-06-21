using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GradProj.Infrastructure.External_Services.Amazon;
using System.Text.RegularExpressions;
using GradProj.Domain.RepositoryAbs;
using GradProj.Application.ServiceAbs;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using GradProj.Application.ServiceImp;

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
        [Authorize]
        [HttpPost("lookup")]
        public async Task<IActionResult> GetProductDetails(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                return BadRequest("URL boş olamaz.");
            var userId = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            try
            {
                var result = await _trackedProductsService.GetProductFromAmazon(url, userId);
                
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
        [Authorize]
        [HttpPost]
        public  IActionResult GetUserTrackedProducts()
        {
            var userid = Guid.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var products =  _trackedProductsService.GetSpecifiedUserProducts(userid);

            if (products == null || !products.Any())
                return NotFound("Kullanıcıya ait ürün bulunamadı.");

            return Ok(products);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteUserProduct(Guid id)
        {
            _trackedProductsService.DeleteAsync(id);
            return NoContent();
        }
    }
}
