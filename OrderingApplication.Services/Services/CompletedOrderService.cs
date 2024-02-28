using OrderingApplication.Services.Contracts;
using OrderingApplication.Web.ViewModels.Cart.CompletedOrders;

namespace OrderingApplication.Services.Services
{
    public class CompletedOrderService : ICompletedOrderService
    {
        private List<CompletedOrdersViewModel> _completedOrders;

        public CompletedOrderService()
        {
            //_completedOrders = new List<CompletedOrdersViewModel>(); TODO
            SeedCatalogData();
        }

        public void CompleteOrder(OrderRequestModel completedOrder)
        {
            try
            {
                if (completedOrder == null)
                {
                    throw new ArgumentNullException(nameof(completedOrder), "The completed order is null.");
                }

                var completedOrdersViewModel = MapToCompletedOrdersViewModel(completedOrder);

                _completedOrders.Add(completedOrdersViewModel);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }


        public List<CompletedOrdersViewModel> GetCompletedOrders()
        {
            try
            {
                return _completedOrders;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCompletedOrders: {ex.Message}");
                return new List<CompletedOrdersViewModel>();
            }
        }

        public int GetCompletedOrdersCount()
        {
            try
            {
                return _completedOrders.Count;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetCompletedOrdersCount: {ex.Message}");
                return 0;
            }
        }

        private void SeedCatalogData()
        {
            _completedOrders = new List<CompletedOrdersViewModel>{
                new CompletedOrdersViewModel
                {
                    Id = "1",
                    Prices = new List<double> { 3.65, 2.10 },
                    Quantities = new List<double> { 1.20, 1.00 },
                    OrderedOn = new DateTime(2024, 1, 1),
                },
            };

            foreach (var order in _completedOrders)
            {
                order.Names = new List<string> { "Banana", "Strawberry" };
                order.Prices = new List<double> { 3.65, 2.10 };
                order.Quantities = new List<double> { 1.20, 1.00 };
            }
        }


        private CompletedOrdersViewModel MapToCompletedOrdersViewModel(OrderRequestModel completedOrder)
        {
            var completedOrdersViewModel = new CompletedOrdersViewModel
            {
                Id = completedOrder.OrderId,
                Names = completedOrder.Items.Select(x => x.Name).ToList(),
                Prices = completedOrder.Items.Select(item => double.Parse(item.Price)).ToList(),
                Quantities = completedOrder.Items.Select(item => double.Parse(item.Quantity)).ToList(),
                OrderedOn = DateTime.UtcNow,
            };


            return completedOrdersViewModel;
        }

    }
}
