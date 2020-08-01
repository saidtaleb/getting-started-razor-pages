namespace WiredBrainCoffee.Pages
{
    using Microsoft.AspNetCore.Mvc.RazorPages;

    public class ConfirmationModel : PageModel
    {
        public string Message { get; set; }

        public void OnGetContact()
        {
            Message = "Your email was sent to our team.";
        }

        public void OnGetSubscribe()
        {
            Message = "You have been added the mailing list.";
        }
    }
}