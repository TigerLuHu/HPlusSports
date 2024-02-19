using HPlusSports.Shared.Models;

using Microsoft.AspNetCore.Mvc.RazorPages;

using Newtonsoft.Json;

namespace HPlusSportsWeb.Pages.Cart
{
    public class HistoryModel : PageModel
    {
        private HttpClient _httpClient;

        public HistoryModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<OrderHistoryEntity> OrderHistoryEntities {  get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetStringAsync("order");
            OrderHistoryEntities = JsonConvert.DeserializeObject<List<OrderHistoryEntity>>(response);
        }
    }
}
