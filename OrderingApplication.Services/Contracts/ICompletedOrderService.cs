using OrderingApplication.Web.ViewModels.Cart.CompletedOrders;

namespace OrderingApplication.Services.Contracts
{
    public interface ICompletedOrderService
    {
        public int GetCompletedOrdersCount();
        List<CompletedOrdersViewModel> GetCompletedOrders();
        void CompleteOrder(OrderRequestModel completedOrder);
    }
}
