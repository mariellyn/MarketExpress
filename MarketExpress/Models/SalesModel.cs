namespace MarketExpress.Models
{
    public class SalesModel
    {

        public int Id { get; set; }

        public string SaleIdentifier { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Client { get; set; }
        public string ProductsSold { get; set; }
        public string Observations { get; set; }
        public string FinalPrice { get; set; }
        public string OrderStatus { get; set; }
        public string Payment { get; set; }

    }
}
