using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HPlusSportsWeb.Pages.Product
{
    public class DetailModel : PageModel
    {
        [BindProperty]
        public HPlusSports.Shared.Models.Product Product { get; set; }
    }
}
