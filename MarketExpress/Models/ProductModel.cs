using System.ComponentModel.DataAnnotations;

namespace MarketExpress.Models
{
    public class ProductModel
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "The product description is required.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The product price is required.")]
        public string Price { get; set; }

        [Required(ErrorMessage = "The product quantity in stock is required.")]
        public string QuantityStock { get; set; }

        [Required(ErrorMessage = "The product weight is required.")]
        public string Weight { get; set; }

        [Required(ErrorMessage = "The product category is required.")]
        public string Category { get; set; }

    }
}
