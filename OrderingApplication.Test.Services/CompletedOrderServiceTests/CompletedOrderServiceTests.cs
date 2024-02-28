using OrderingApplication.Services.Contracts;
using OrderingApplication.Services.Services;
using OrderingApplication.Web.ViewModels.Cart.CompletedOrders;

namespace OrderingApplication.Test.Services.CompletedOrderServiceTests
{
    [TestClass]
    public class CompletedOrderServiceTests
    {
        private ICompletedOrderService _completedOrder;

        [TestInitialize]
        public void Setup()
        {
            _completedOrder = new CompletedOrderService();
        }

        [TestMethod]
        public void GetComletedOrders_ShouldReturnInitializedList()
        {
            // Act

            var results = _completedOrder.GetCompletedOrders();

            // Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(1, results.Count);
        }

        [TestMethod]
        public void GetCompletedOrders_ShouldReturnCorrectCount()
        {
            //Act
            int ordersCount = _completedOrder.GetCompletedOrders().Count();

            // Assert
            Assert.AreEqual(1, ordersCount);
        }

        [TestMethod]

        public void CompletedOrders_ShouldCompleteOrderAndAddToList()
        {

            // Arrange
            var itemOrder = new OrderItemModel
            {
                Id = 9,
                Name = "Blueberry",
                Quantity = "2",
                Price = "3",
            };

            var order = new OrderRequestModel
            {

                OrderId = "10",
                Items = new List<OrderItemModel>
                {
                    itemOrder
                }
            };

            // Act
            _completedOrder.CompleteOrder(order);
            var count = _completedOrder.GetCompletedOrdersCount();


            // Assert
            Assert.IsNotNull(_completedOrder);
            Assert.AreEqual(2, count);
        }
    }
}
