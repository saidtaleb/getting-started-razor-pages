namespace WiredBrainCoffee.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Linq;
    using WiredBrainCoffee.Models;
    using WiredBrainCoffee.Services;

    public class ItemModel : PageModel
    {
        public MenuItem Item { get; private set; }
        private readonly IMenuService _menuService;

        public ItemModel(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public void OnGet(string slug)
        {
            Item = _menuService.GetMenuItems()
                        .FirstOrDefault(e => e.Slug == slug);
        }
    }
}
