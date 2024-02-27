using Microsoft.AspNetCore.Mvc;
using OrderingApplication.Services.Contracts;
using OrderingApplication.Web.ViewModels.Cart.CompletedOrders;

namespace OrderingApplication.Web.Controllers
{
    public class CompletedOrdersController : Controller
    {
        private readonly ICompletedOrderService _completedOrderService;

        public CompletedOrdersController(ICompletedOrderService completedOrderService)
        {
            _completedOrderService = completedOrderService;
        }

        [Route("GetCompleted")]
        public IActionResult GetCompletedOrders()
        {
            var carts = _completedOrderService.GetCompletedOrders();
            var completedCartsViewModel = new CompletedCartsViewModel
            {
                Items = carts
            };

            return View(completedCartsViewModel);
        }


        [HttpPost]
        public IActionResult CompleteOrder([FromBody] OrderRequestModel orderRequest)
        {
            try
            {
                _completedOrderService.CompleteOrder(orderRequest);

                return Ok(new { Message = "Order placed successfully!" });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in CompleteOrder: {ex.Message}");
                return BadRequest(new { Message = "Failed to complete the order." });
            }
        }


    }
}
