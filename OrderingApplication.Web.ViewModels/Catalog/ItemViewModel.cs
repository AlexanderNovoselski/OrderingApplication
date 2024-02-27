using OrderingApplication.Web.ViewModels.Catalog.Enum;

public class ItemViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }

    public double Quantity { get; set; }
    public PriceMode PriceMode { get; set; }

}
