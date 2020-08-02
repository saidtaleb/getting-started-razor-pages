namespace WiredBrainCoffee.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using WiredBrainCoffee.Models;
    using WiredBrainCoffee.Services;
    using System;

    public class MenuModel : PageModel
    {
        private readonly IMenuService _menuService;
        private readonly ILogger<MenuModel> _logger;
        public List<MenuItem> Menu { get; set; }

        public MenuModel(IMenuService menuService, ILogger<MenuModel> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        public void OnGet()
        {
            try
            {
                Menu = _menuService.GetMenuItems();
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.Information, ex, "Could not retrieve menu");
            }
        }
    }
}
