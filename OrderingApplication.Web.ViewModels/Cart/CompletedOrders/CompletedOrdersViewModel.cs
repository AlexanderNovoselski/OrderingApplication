namespace OrderingApplication.Web.ViewModels.Cart.CompletedOrders
{
    public class CompletedOrdersViewModel
    {
        public string Id { get; set; }
        public List<string> Names { get; set; }
        public List<double> Prices { get; set; }
        public List<double> Quantities { get; set; }
        public DateTime OrderedOn { get; set; }

        private readonly double _vat = 20;

        public List<double> Totals => CalculateTotals();
        public List<double> TotalsWithVAT => CalculateTotalsWithVAT();

        private List<double> CalculateTotals()
        {
            List<double> totals = new List<double>();
            for (int i = 0; i < Prices.Count; i++)
            {
                totals.Add(Prices[i] * Quantities[i]);
            }
            return totals;
        }

        private List<double> CalculateTotalsWithVAT()
        {
            List<double> totalsWithVAT = new List<double>();
            for (int i = 0; i < Prices.Count; i++)
            {
                double total = Prices[i] * Quantities[i];
                totalsWithVAT.Add(total + total * (_vat / 100));
            }
            return totalsWithVAT;
        }
    }
}
