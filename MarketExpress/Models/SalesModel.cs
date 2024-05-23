using System.ComponentModel.DataAnnotations;

namespace MarketExpress.Models
{
    public class SalesModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "The sale identifier is required.")]
        public string SaleIdentifier { get; set; }

        [Required(ErrorMessage = "The sale date is required.")]
        public string Date { get; set; }

        [Required(ErrorMessage = "The sale hour is required.")]
        public string Hour { get; set; }

        [Required(ErrorMessage = "The client is required.")]
        public string Client { get; set; }

        [Required(ErrorMessage = "The products sold are required.")]
        public string ProductsSold { get; set; }

        [Required(ErrorMessage = "The observations are required.")]
        public string Observations { get; set; }

        [Required(ErrorMessage = "The final price is required.")]
        public string FinalPrice { get; set; }

        [Required(ErrorMessage = "The order status is required.")]
        public string OrderStatus { get; set; }

        [Required(ErrorMessage = "The payment status is required.")]
        public string Payment { get; set; }

    }
}
