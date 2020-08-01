namespace WiredBrainCoffee
{
    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using System.Threading.Tasks;
    using WiredBrainCoffee.Services;

    public class PopularBrews : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var menu = new MenuService();
            var items = menu.GetMenuItems().Take(count);
            return View(items);
        }
    }
}
