using Ejercicio8.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Ejercicio8.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsControllerV2 : ControllerBase
    {
        private const string ApiTestUrl = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsControllerV2(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        [Route("GetProductsWithGuid")]
        public async Task<IActionResult> GetProductList()
        {
            _httpClient.DefaultRequestHeaders.Clear();

            var response = await _httpClient.GetStreamAsync(ApiTestUrl);
            var data = await JsonSerializer.DeserializeAsync<List<ProductV2>>(response);

            return Ok(data);
        }
    }
}
