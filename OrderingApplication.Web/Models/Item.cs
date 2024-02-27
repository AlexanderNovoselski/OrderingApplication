using System.ComponentModel.DataAnnotations;
using OrderingApplication.Web.ViewModels.Catalog.Enum;

public class Item
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Price is required.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Price mode is required.")]
    public PriceMode PriceMode { get; set; }
}
