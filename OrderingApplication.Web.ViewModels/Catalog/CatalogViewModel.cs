public class CatalogViewModel
{
    public List<ItemViewModel> Items { get; set; } = new List<ItemViewModel>();

    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
}
