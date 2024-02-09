using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

namespace HPlusSportsWeb.Pages.Product
{
    public class IndexModel : PageModel
    {
        private HttpClient _httpClient;

        public IndexModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<HPlusSports.Shared.Models.ProductBase> Products { get; set; } = new List<HPlusSports.Shared.Models.ProductBase>();

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetStringAsync("product");
            Products = JsonConvert.DeserializeObject<List<HPlusSports.Shared.Models.ProductBase>>(response);
        }
    }
}
