namespace WiredBrainCoffee.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class FeedbackModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your contact page.";
        }
    }
}
