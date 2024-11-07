using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPageSample1.Models;
using RazorPageSample1.Services;

namespace RazorPageSample1.Pages.Products
{
    public class ProductPageModel : PageModel
    {
        private readonly ILogger<ProductPageModel> _logger;
        private ProductService _productService;
        public Product? Product { get; set; }
        public List<Product> products;

        public ProductPageModel(ProductService productService, ILogger<ProductPageModel> logger)
        {
            _logger = logger;
            _productService = productService;
            products = productService.GetProducts();

            _logger.LogInformation($"ProductPageModel instance created. Instance ID: {this.GetHashCode()}");
        }

        public void OnGet(int? id)
        {
            if (id == null)
            {
                ViewData["Title"] = $"Danh sách sản phẩm";
            }
            else
            {
                ViewData["Title"] = $"Thông tin sản phẩm (ID={id.Value})";
                Product = products.Find(x => x.Id == id.Value);
            }
        }

        public IActionResult OnGetLastProduct()
        {
            ViewData["Title"] = $"Sản phẩm cuối";
            Product = products.LastOrDefault();
            if (Product != null)
            {
                return Page();
            }
            return NotFound();
        }

        public IActionResult OnGetRemoveAll()
        {
            products.Clear();
            _productService.GetProducts().Clear();
            return RedirectToPage("Index");
        }

        public IActionResult OnGetLoadAll()
        {
            _productService.LoadProducts();
            products = _productService.GetProducts();
			return RedirectToPage("Index");
		}
    }
}
