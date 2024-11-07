using RazorPageSample1.Models;

namespace RazorPageSample1.Services
{
	public class ProductService
	{
		private int nextId = 3;
		private List<Product> products = new List<Product>();

		public ProductService()
		{
			LoadProducts();
		}

		public void Add(Product product)
		{
			product.Id = nextId++;
			products.Add(product);
		}

		public void Update(Product product) {
			var existingProduct = products.Find(x => x.Id == product.Id);
			if (existingProduct != null)
			{
				existingProduct.Name = product.Name;
				existingProduct.Description = product.Description;
				existingProduct.Price = product.Price;
			}
		}

		public void Delete(int id)
		{
			var product = products.FirstOrDefault(p => p.Id == id);
			if (product != null)
			{
				products.Remove(product);
			}
		}

		public List<Product> GetProducts() => products;

		public Product? GetProductByID(int id) => products.FirstOrDefault(p => p.Id == id);

		public void LoadProducts()
		{
			products.AddRange(new List<Product>()
				{
					new Product()
					{
						Id = 0,
						Name = "Iphone 14 Pro",
						Description = "Apple",
						Price = 1400
					},
					new Product()
					{
						Id = 1,
						Name = "Samsung Galaxy S24 Ultra",
						Description = "Samsung",
						Price = 2899
					},
					new Product()
					{
						Id = 2,
						Name = "Sony Xperia",
						Description = "Sony",
						Price = 799
					}
				}
			);
		}
	}
}
