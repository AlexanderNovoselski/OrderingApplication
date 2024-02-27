using OrderingApplication.Web.ViewModels.Catalog.Enum;

namespace OrderingApplication.Web.ViewModels.Cart.PendingOrders
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Quantity { get; set; }

        public PriceMode PriceMode { get; set; }

        public static double VAT => 20;

        public double Total => Price * Quantity;

        public double TotalWithVAT => Total + Total * (VAT / 100);
    }
}
