using Ejercicio8.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ejercicio8.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string ApiTestUrl = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProductList()
        {
            _httpClient.DefaultRequestHeaders.Clear();

            var response = await _httpClient.GetStreamAsync(ApiTestUrl);
            var data = await JsonSerializer.DeserializeAsync<List<Product>>(response);

            return Ok(data);
        }
    }
}
