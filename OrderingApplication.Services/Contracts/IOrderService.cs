using OrderingApplication.Web.ViewModels.Cart.PendingOrders;

namespace OrderingApplication.Services.Contracts
{
    public interface IOrderService
    {
        List<CartItemViewModel> GetCurrentOrder();
        void AddItemToOrder(CartItemViewModel item);
        void RemoveItemFromOrder(int itemId);

        void ClearCart();
    }
}
