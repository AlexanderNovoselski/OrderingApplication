using Microsoft.AspNetCore.Mvc;
using OrderingApplication.Services.Contracts;
using OrderingApplication.Web.Models.HTTPModels.Cart;
using OrderingApplication.Web.ViewModels.Cart.PendingOrders;
using OrderingApplication.Web.ViewModels.Catalog.Enum;

namespace OrderingApplication.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly IOrderService _orderService;

        public CartController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [Route("Cart")]
        public IActionResult Cart()
        {
            var cartViewModel = new CartViewModel
            {
                Items = _orderService.GetCurrentOrder()
            };

            return View(cartViewModel);
        }


        [HttpPost]
        public IActionResult AddToCart([FromBody] AddToCartBody model)
        {
            try
            {
                var quantityReal = double.Parse(model.Quantity);
                var price = double.Parse(model.ItemPrice);
                var id = int.Parse(model.ItemId);

                if (Enum.TryParse(model.PriceMode, out PriceMode parsedPriceMode))
                {
                    _orderService.AddItemToOrder(new CartItemViewModel
                    {
                        Id = id,
                        Name = model.ItemName,
                        Price = price,
                        PriceMode = parsedPriceMode,
                        Quantity = quantityReal
                    });
                }
                else
                {
                    Console.WriteLine("Invalid PriceMode value");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return RedirectToAction("GetItems", "Item");
        }

        [HttpDelete]
        public IActionResult RemoveItem([FromBody] RemoveItemFromCartBody model)
        {
            _orderService.RemoveItemFromOrder(model.itemId);

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            _orderService.ClearCart();

            return Json(new { redirectTo = Url.Action("Cart") });
        }

    }
}
