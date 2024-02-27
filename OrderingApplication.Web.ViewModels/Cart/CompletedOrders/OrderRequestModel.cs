namespace OrderingApplication.Web.ViewModels.Cart.CompletedOrders
{
    public class OrderRequestModel
    {
        public string OrderId { get; set; }
        public List<OrderItemModel> Items { get; set; }
    }
}
