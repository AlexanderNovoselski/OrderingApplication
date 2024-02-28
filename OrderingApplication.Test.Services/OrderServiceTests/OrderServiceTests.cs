using OrderingApplication.Services.Contracts;
using OrderingApplication.Services.Services;
using OrderingApplication.Web.ViewModels.Cart.PendingOrders;
using OrderingApplication.Web.ViewModels.Catalog.Enum;

namespace OrderingApplication.Test.Services.OrderServiceTests;

[TestClass]
public class OrderServiceTests
{
    private IOrderService orderService;

    [TestInitialize]
    public void Setup()
    {
        orderService = new OrderService();
    }

    [TestMethod]
    public void GetCurrentOrder_ShouldReturnInitializedList()
    {
        // Arrange
        var result = orderService.GetCurrentOrder();

        // Assert
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Count);
    }

    [TestMethod]
    public void AddItemToOrder_ShouldIncreaseItemCount()
    {
        // Arrange
        var initialItemCount = orderService.GetCurrentOrder().Count;

        // Act
        orderService.AddItemToOrder(new CartItemViewModel { Id = 2, Name = "Apple", Price = 1, PriceMode = PriceMode.PerItem, Quantity = 2 });

        // Assert
        var result = orderService.GetCurrentOrder();
        Assert.AreEqual(initialItemCount + 1, result.Count);
        Assert.IsTrue(result.Any(item => item.Id == 2));
    }

    [TestMethod]
    public void RemoveItemFromOrder_ShouldDecreaseItemCount()
    {
        // Arrange
        var initialItemCount = orderService.GetCurrentOrder().Count;

        // Act
        orderService.RemoveItemFromOrder(1);

        // Assert
        var result = orderService.GetCurrentOrder();
        Assert.AreEqual(initialItemCount - 1, result.Count);
        Assert.IsFalse(result.Any(item => item.Id == 1));
    }

    [TestMethod]
    public void ClearCart_ShouldRemoveAllItems()
    {
        // Arrange
        var initialItemCount = orderService.GetCurrentOrder().Count;

        // Act
        orderService.ClearCart();

        // Assert
        var result = orderService.GetCurrentOrder();
        Assert.AreEqual(0, result.Count);
    }
}
