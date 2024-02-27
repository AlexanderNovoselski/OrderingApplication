public interface ICatalogService
{
    public int GetCatalogItemsCount();
    List<ItemViewModel> GetCatalogItems(int page, int pageSize);
    void AddCatalogItem(ItemViewModel item);
}