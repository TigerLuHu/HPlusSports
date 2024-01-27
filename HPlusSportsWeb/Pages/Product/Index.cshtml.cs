
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HPlusSportsWeb.Pages.Product
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<HPlusSports.Shared.Models.Product> Products { get; set; } = new List<HPlusSports.Shared.Models.Product>();
    }
}
