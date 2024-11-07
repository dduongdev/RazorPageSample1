using System.ComponentModel;

namespace RazorPageSample1.Models
{
    public class Product
    {
        public int Id { get; set; }

        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; } = string.Empty;

        [DisplayName("Mô tả sản phẩm")]
        public string Description { get; set; } = string.Empty;

        [DisplayName("Giá sản phẩm")]
        public decimal Price { get; set; }
    }
}
