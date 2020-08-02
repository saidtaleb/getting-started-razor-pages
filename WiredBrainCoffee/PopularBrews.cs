namespace WiredBrainCoffee
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using WiredBrainCoffee.Services;

    public class PopularBrews : ViewComponent
    {
        private readonly IMenuService _menuService;

        public PopularBrews(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var items = _menuService.GetMenuItems().Take(count);
            return View(items);
        }
    }
}
