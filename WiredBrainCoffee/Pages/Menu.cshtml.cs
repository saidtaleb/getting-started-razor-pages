namespace WiredBrainCoffee.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using System.Collections.Generic;
    using WiredBrainCoffee.Models;
    using WiredBrainCoffee.Services;

    public class MenuModel : PageModel
    {
        public List<MenuItem> Menu { get; set; }

        public void OnGet()
        {
            var menuService = new MenuService();
            Menu = menuService.GetMenuItems();
        }
    }
}
