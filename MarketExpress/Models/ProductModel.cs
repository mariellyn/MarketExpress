using System.ComponentModel.DataAnnotations;

namespace MarketExpress.Models
{
    public class ProductModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter description product")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Enter price product")]
        public string Price { get; set; }

        [Required(ErrorMessage = "Enter quantity stock product")]
        public string QuantityStock { get; set; }

        
        public string Weigth { get; set; }

        [Required(ErrorMessage = "Enter category product")]
        public string Category { get; set; }

    }
}
