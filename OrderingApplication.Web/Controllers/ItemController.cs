using Microsoft.AspNetCore.Mvc;

public class ItemController : Controller
{
    private readonly ICatalogService _catalogService;

    public ItemController(ICatalogService catalogService)
    {
        _catalogService = catalogService;
    }

    public IActionResult GetItems(int page = 1, int pageSize = 6)
    {
        var catalogItems = _catalogService.GetCatalogItems(page - 1, pageSize);

        int totalItems = _catalogService.GetCatalogItemsCount();
        int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

        var catalogViewModel = new CatalogViewModel
        {
            Items = catalogItems,
            TotalPages = totalPages,
            CurrentPage = page
        };

        return View(catalogViewModel);
    }

    [Route("Create")]
    public IActionResult CreateItemView()
    {
        return View("CreateItemView");
    }


    [HttpPost]
    public IActionResult CreateItem(Item newItem)
    {
        if (ModelState.IsValid)
        {
            var itemsCount = _catalogService.GetCatalogItemsCount();

            var newItemViewModel = new ItemViewModel
            {
                Id = itemsCount + 1,
                Name = newItem.Name,
                Price = newItem.Price,
                PriceMode = newItem.PriceMode,
                Quantity = 1
            };

            _catalogService.AddCatalogItem(newItemViewModel);

            return RedirectToAction("GetItems");
        }
        else
        {
            TempData["ErrorMessage"] = "Failed to create item. Please check your inputs.";
            return RedirectToAction("CreateItemView");
        }
    }




}
