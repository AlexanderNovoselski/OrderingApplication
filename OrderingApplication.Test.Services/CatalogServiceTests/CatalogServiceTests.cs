using OrderingApplication.Web.ViewModels.Catalog.Enum;

namespace OrderingApplication.Test.Services.CatalogServiceTests
{
    [TestClass]
    public class CatalogServiceTest
    {
        private ICatalogService catalogService;

        [TestInitialize]
        public void Setup()
        {
            catalogService = new CatalogService();
        }

        [TestMethod]
        public void GetCatalogItemsCount_ShouldReturnCorrectCount()
        {
            // Act
            int itemCount = catalogService.GetCatalogItemsCount();

            // Assert
            Assert.AreEqual(7, itemCount); // 7 because currently I am seeding that many in my service
        }

        [TestMethod]
        public void GetCatalogItems_ShouldReturnCorrectPage()
        {
            // Arrange
            int page = 0; // as first page is 0 to effiency get the elements we need to skip so 0 * page size will give 0 elements to skip
            int pageSize = 3;

            // Act
            List<ItemViewModel> items = catalogService.GetCatalogItems(page, pageSize);

            // Assert
            Assert.AreEqual(3, items.Count);
            Assert.AreEqual("Banana", items[0].Name);
            Assert.AreEqual("Apple", items[1].Name);
            Assert.AreEqual("Strawberry", items[2].Name);

            // test 2
            // Arrange
            int page2 = 1; // as first page is 0 to effiency get the elements we need to skip so 0 * page size will give 0 elements to skip
            int pageSize2 = 3;

            // Act
            List<ItemViewModel> items2 = catalogService.GetCatalogItems(page2, pageSize2);

            // Assert
            Assert.AreEqual(3, items2.Count);
            Assert.AreEqual("Grapes", items2[0].Name);
            Assert.AreEqual("Watermelon", items2[1].Name);
            Assert.AreEqual("Melon", items2[2].Name);
        }

        [TestMethod]
        public void AddCatalogItem_ShouldIncreaseItemCount()
        {
            // Arrange
            int initialItemCount = catalogService.GetCatalogItemsCount();
            var newItem = new ItemViewModel { Id = 8, Name = "Orange", Price = 2.50, PriceMode = PriceMode.PerKg, Quantity = 1.00 };

            // Act
            catalogService.AddCatalogItem(newItem);

            // Assert
            int updatedItemCount = catalogService.GetCatalogItemsCount();
            Assert.AreEqual(initialItemCount + 1, updatedItemCount);
        }
    }
}
