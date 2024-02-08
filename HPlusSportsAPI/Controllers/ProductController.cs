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
        public async Task<JsonResult> AddClothing(ClothingProduct cloth)
        {
            var newCloth = await _productService.AddProductAsync(cloth);
            return new JsonResult(newCloth);
        }

        [HttpPost("nutrition")]
        public async Task<JsonResult> AddNutritional(NutritionalProduct nutrition)
        {
            var newNutrition = await _productService.AddProductAsync(nutrition);
            return new JsonResult(newNutrition);
        }
    }
}
