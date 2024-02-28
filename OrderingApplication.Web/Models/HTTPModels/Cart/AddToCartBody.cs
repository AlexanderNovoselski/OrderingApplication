namespace OrderingApplication.Web.Models.HTTPModels.Cart
{
    public class AddToCartBody
    {
        public string ItemId { get; set; }
        public string ItemName { get; set; }
        public string ItemPrice { get; set; }
        public string Quantity { get; set; }
        public string PriceMode { get; set; }
    }
}
