using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageSample1.Models;
using RazorPageSample1.Services;

namespace RazorPageSample1.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductService _service;

        public CreateModel(ProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Add(Product);
            return RedirectToPage("Index");
        }
    }
}
