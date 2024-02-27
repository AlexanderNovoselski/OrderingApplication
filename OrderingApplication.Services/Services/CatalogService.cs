using OrderingApplication.Web.ViewModels.Catalog.Enum;

public class CatalogService : ICatalogService
{
    private List<ItemViewModel> _catalogItems;

    public CatalogService()
    {
        SeedCatalogData();
    }

    public int GetCatalogItemsCount()
    {
        return _catalogItems.Count;
    }

    public List<ItemViewModel> GetCatalogItems(int page, int pageSize)
    {
        try
        {
            int startIndex = page * pageSize;
            var items = _catalogItems.Skip(startIndex).Take(pageSize).ToList();

            return items;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return new List<ItemViewModel>();
        }

    }

    public void AddCatalogItem(ItemViewModel item)
    {
        try
        {
        _catalogItems.Add(item);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    private void SeedCatalogData()
    {
        _catalogItems = new List<ItemViewModel>
        {
            new ItemViewModel { Id = 1, Name = "Banana", Price = 3.65, PriceMode = PriceMode.PerKg, Quantity = 1.00},
            new ItemViewModel { Id = 2, Name = "Apple", Price = 2.10, PriceMode = PriceMode.PerKg, Quantity = 1.00},
            new ItemViewModel { Id = 3, Name = "Strawberry", Price = 3.25, PriceMode = PriceMode.PerKg, Quantity = 1.00},
            new ItemViewModel { Id = 4, Name = "Grapes", Price = 4.2, PriceMode = PriceMode.PerKg, Quantity = 1.00},
            new ItemViewModel { Id = 5, Name = "Watermelon", Price = 2.10, PriceMode = PriceMode.PerKg, Quantity = 1.00},
            new ItemViewModel { Id = 6, Name = "Melon", Price = 5.25, PriceMode = PriceMode.PerItem, Quantity = 1.00},
            new ItemViewModel { Id = 7, Name = "Water", Price = 1.25, PriceMode = PriceMode.PerLiter, Quantity = 1.00},
        };
    }
}