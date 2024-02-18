using HPlusSports.Shared.Models;

using HPlusSportsWeb.Pages.Extensions;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

using System.Net.Http.Headers;

namespace HPlusSportsWeb.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [BindProperty]
        public ClothingProduct Cloth { get; set; }

        [BindProperty]
        public NutritionalProduct Nutrition { get; set; }

        public string ProgressMessage { get; set; }

        public async Task<IActionResult> OnPostCreateNewClothAsync()
        {
            var emptyCloth = new ClothingProduct();
            if (await TryUpdateModelAsync(
                emptyCloth,
                "cloth",
                c => c.Name, c => c.Description, c => c.Sizes))
            {
                var response = await _httpClient.PostAsJsonAsync("product/clothing", emptyCloth);

                if(response.IsSuccessStatusCode)
                {
                    var contentString = await response.Content.ReadAsStringAsync();
                    Cloth = JsonConvert.DeserializeObject<ClothingProduct>(contentString);
                    HttpContext.Session.SetObject(nameof(Cloth), Cloth);
                    ProgressMessage = "Clothing product Created";

                    return Page();
                }
                else
                {
                    throw new ApplicationException(response.ReasonPhrase);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> OnPostAddClothImageAsync(IFormFile imageFile)
        {
            var cloth = HttpContext.Session.GetObject<ClothingProduct>(nameof(Cloth));
            var result = await UplaodProductImage(imageFile, cloth);
            Cloth = result.Product;
            HttpContext.Session.SetObject(nameof(Cloth), Cloth);
            return result.ActionResult;
        }

        public async Task OnPostCreateNewNutritionAsync()
        {
            var emptyNutrition = new NutritionalProduct();
            if (await TryUpdateModelAsync(
                emptyNutrition,
                "Nutrition",
                c => c.Name, c => c.Description))
            {
                var response = await _httpClient.PostAsJsonAsync("product/nutrition", emptyNutrition);

                if (response.IsSuccessStatusCode)
                {
                    var contentString = await response.Content.ReadAsStringAsync();
                    Nutrition = JsonConvert.DeserializeObject<NutritionalProduct>(contentString);
                    HttpContext.Session.SetObject(nameof(Nutrition), Nutrition);
                    ProgressMessage = "Nutritional product Created";
                }
            }
        }

        public async Task<IActionResult> OnPostAddNutritionImageAsync(IFormFile imageFile)
        {
            var nutrition = HttpContext.Session.GetObject<NutritionalProduct>(nameof(Nutrition));
            var result = await UplaodProductImage(imageFile, nutrition);
            Nutrition = result.Product;
            HttpContext.Session.SetObject(nameof(Nutrition), Nutrition);
            return result.ActionResult;
        }

        private async Task<(IActionResult ActionResult, T Product)> UplaodProductImage<T>(IFormFile imageFile, T product) where T : ProductBase
        {
            if (imageFile.Length < 0)
            {
                return (BadRequest(), product);
            }

            var imageContent = new StreamContent(imageFile.OpenReadStream());
            imageContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
            {
                Name = "imageFile",
                FileName = imageFile.FileName
            };

            var putContent = new MultipartFormDataContent
            {
                { imageContent, "imageFile" }
            };

            var response = await _httpClient.PutAsync($"product/image/{product.Id}", putContent);
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.ReasonPhrase);
            }

            var contentString = await response.Content.ReadAsStringAsync();
            product = JsonConvert.DeserializeObject<T>(contentString);
            ProgressMessage = "Image added";

            return (Page(), product);
        }
    }
}
