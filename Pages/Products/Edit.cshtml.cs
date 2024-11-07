using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageSample1.Models;
using RazorPageSample1.Services;

namespace RazorPageSample1.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductService _service;

        public EditModel(ProductService service)
        {
            _service = service;
        }

        [BindProperty]
        public Product Product { get; set; } = default!;

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = _service.GetProductByID(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            Product = product;
            return Page();
        }

        public IActionResult OnPost()
        {
            var existingProduct = _service.GetProductByID(Product.Id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            
            _service.Update(Product);
            return RedirectToPage("Index");
        }
    }
}
