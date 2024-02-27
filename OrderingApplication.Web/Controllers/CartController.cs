﻿using Microsoft.AspNetCore.Mvc;
using OrderingApplication.Services.Contracts;
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
        public IActionResult AddToCart(int itemId, string itemName, double itemPrice, string quantity, PriceMode priceMode)
        {
            try
            {
                var quantityReal = double.Parse(quantity);

                _orderService.AddItemToOrder(new CartItemViewModel
                {
                    Id = itemId,
                    Name = itemName,
                    Price = itemPrice,
                    PriceMode = priceMode,
                    Quantity = quantityReal
                });

            }
            catch (Exception e)
            {
                Console.WriteLine(e);

            }
            return RedirectToAction("GetItems", "Item");
        }


        [HttpDelete]
        public IActionResult RemoveItem(int itemId)
        {
            _orderService.RemoveItemFromOrder(itemId);

            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult ClearCart()
        {
            _orderService.ClearCart();

            return RedirectToAction("Cart");
        }



    }
}