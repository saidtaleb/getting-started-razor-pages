namespace WiredBrainCoffee.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Linq;
    using WiredBrainCoffee.Models;
    using WiredBrainCoffee.Services;

    public class ItemModel : PageModel
    {
        public MenuItem Item { get; private set; }

        public void OnGet(string slug)
        {
            var menuService = new MenuService();
            Item = menuService
                        .GetMenuItems()
                        .FirstOrDefault(e => e.Slug == slug);
        }
    }
}
