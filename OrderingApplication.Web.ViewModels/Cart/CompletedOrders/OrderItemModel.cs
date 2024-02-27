namespace OrderingApplication.Web.ViewModels.Cart.CompletedOrders
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public string TotalWithoutVAT { get; set; }
    }
}
