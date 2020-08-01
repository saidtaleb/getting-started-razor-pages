namespace WiredBrainCoffee.Pages
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using WiredBrainCoffee.Models;
    using WiredBrainCoffee.Services;

    public class ContactModel : PageModel
    {
        [BindProperty]
        public Contact Contact { get; set; }
        public string Message { get; set; }

        public void OnGet()
        { }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                EmailService.SendEmail(Contact);
                //Message = "Your email has been sent.";
                return new RedirectToPageResult("Confirmation", "Contact");
            }

            return Page();
        }

        public IActionResult OnPostSubscribe(string address)
        {
            EmailService.SendEmail(address);
            //Message = "You have been added to the mailing list.";
            return new RedirectToPageResult("Confirmation", "Subscribe");
        }

    }
}
