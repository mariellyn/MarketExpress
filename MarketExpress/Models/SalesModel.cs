using System.ComponentModel.DataAnnotations;

namespace MarketExpress.Models
{
    public class SalesModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Enter identifier sale")]
        public string SaleIdentifier { get; set; }

        [Required(ErrorMessage = "Enter date sale")]
        public string Date { get; set; }

        [Required(ErrorMessage = "Enter hour sale")]
        public string Hour { get; set; }

        [Required(ErrorMessage = "Enter client sale")]
        public string Client { get; set; }

        [Required(ErrorMessage = "Enter product sold sale")]
        public string ProductsSold { get; set; }

        [Required(ErrorMessage = "Enter observations sale")]
        public string Observations { get; set; }

        [Required(ErrorMessage = "Enter final price sale")]
        public string FinalPrice { get; set; }

       
        public string OrderStatus { get; set; }
        public string Payment { get; set; }

    }
}
