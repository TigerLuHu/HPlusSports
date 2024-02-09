using HPlusSports.Shared.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

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

        public async Task OnPostCreateNewClothAsync()
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
                    ProgressMessage = "Clothing product Created";
                }
            }
        }

        public async Task OnPostAddClothImageAsync()
        {

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
                    ProgressMessage = "Nutritional product Created";
                }
            }
        }

        public async Task OnPostAddNutritionImageAsync()
        {

        }
    }
}
