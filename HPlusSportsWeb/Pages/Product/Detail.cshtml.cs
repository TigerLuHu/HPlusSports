using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

namespace HPlusSportsWeb.Pages.Product
{
    public class DetailModel : PageModel
    {
        private HttpClient _httpClient;

        public DetailModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public HPlusSports.Shared.Models.ProductBase Product { get; set; }

        public async Task OnGetAsync(string id)
        {
            var response = await _httpClient.GetStringAsync($"product/{id}");
            Product = JsonConvert.DeserializeObject<HPlusSports.Shared.Models.ProductBase>(response);
        }
    }
}
