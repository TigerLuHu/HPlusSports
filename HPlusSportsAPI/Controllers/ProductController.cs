using HPlusSports.Shared.Models;

using HPlusSportsAPI.Services.Domain;

using Microsoft.AspNetCore.Mvc;

namespace HPlusSportsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService<ProductBase> _productService;

        public ProductController(IProductService<ProductBase> productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<JsonResult> Get()
        {
            var products = await _productService.GetProductsAsync();
            return new JsonResult(products);
        }

        [HttpGet("{id}")]
        public async Task<JsonResult> Get(string id) 
        {
            var product = await _productService.GetProductAsync(id);
            return new JsonResult(product);
        }

        [HttpPost("clothing")]
        public async Task<JsonResult> AddClothing([FromBody]ClothingProduct cloth)
        {
            if (string.IsNullOrWhiteSpace(cloth.Id))
            {
                cloth.Id = Guid.NewGuid().ToString();
            }

            var newCloth = await _productService.AddProductAsync(cloth);
            return new JsonResult(newCloth);
        }

        [HttpPost("nutrition")]
        public async Task<JsonResult> AddNutritional(NutritionalProduct nutrition)
        {
            if (string.IsNullOrWhiteSpace(nutrition.Id))
            {
                nutrition.Id = Guid.NewGuid().ToString();
            }

            var newNutrition = await _productService.AddProductAsync(nutrition);
            return new JsonResult(newNutrition);
        }

        [HttpPut("image/{id}")]
        public async Task<IActionResult> AddImage(IFormFile imageFile)
        {
            string id = (string)RouteData.Values["id"];

            if(!Request.HasFormContentType)
            {
                return new UnsupportedMediaTypeResult();
            }

            using (var imageStream = imageFile.OpenReadStream())
            {
                try
                {
                    var product = await _productService.AddProductImage(id, imageStream);
                    return new JsonResult(product);
                }
                catch
                {
                    throw;
                }
            }
        }
    }
}
