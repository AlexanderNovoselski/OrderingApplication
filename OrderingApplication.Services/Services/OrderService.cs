using OrderingApplication.Services.Contracts;
using OrderingApplication.Web.ViewModels.Cart.PendingOrders;
using OrderingApplication.Web.ViewModels.Catalog.Enum;

namespace OrderingApplication.Services.Services
{
    public class OrderService : IOrderService
    {
        private List<CartItemViewModel> _cartItems;

        public OrderService()
        {
            SeedCatalogData();
        }

        public List<CartItemViewModel> GetCurrentOrder()
        {
            return _cartItems;
        }

        public void AddItemToOrder(CartItemViewModel item)
        {
            try
            {
                _cartItems.Add(item);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void RemoveItemFromOrder(int itemId)
        {
            try
            {
                var itemToRemove = _cartItems.FirstOrDefault(item => item.Id == itemId);
                if (itemToRemove != null)
                {
                    _cartItems.Remove(itemToRemove);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

        }
        public void ClearCart()
        {
            try
            {
                _cartItems.Clear();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void SeedCatalogData()
        {
            _cartItems = new List<CartItemViewModel>
            {
                new CartItemViewModel { Id = 1, Name = "Banana", Price = 2, PriceMode = PriceMode.PerItem, Quantity = 1.55},
            };
        }
    }
}
