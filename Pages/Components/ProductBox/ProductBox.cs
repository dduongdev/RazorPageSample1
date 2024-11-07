using Microsoft.AspNetCore.Mvc;
using RazorPageSample1.Models;
using RazorPageSample1.Services;

namespace RazorPageSample1.Pages.Components.ProductBox
{
	public class ProductBox : ViewComponent
	{
		private ProductService _productService;

		public ProductBox(ProductService productService)
		{
			_productService = productService;
		}

		//public IViewComponentResult Invoke()
		//{
		//	return View<List<Product>>(products);
		//}

		public async Task<IViewComponentResult> InvokeAsync(bool sapxeptrang = true)
		{
			List<Product> _products = null;
			if (sapxeptrang)
			{
				_products = _productService.GetProducts().OrderBy(p => p.Price).ToList();
			}
			else
			{
				_products = _productService.GetProducts().OrderByDescending(p => p.Price).ToList();
			}
			return View<List<Product>>(_products);
		}
	}
}
