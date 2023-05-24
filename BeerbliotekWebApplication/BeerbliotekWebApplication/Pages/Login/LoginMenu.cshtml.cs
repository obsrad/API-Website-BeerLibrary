using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeerbliotekWebApplication.Pages.Login
{
    public class LoginMenuModel : PageModel
    {
        DatabaseContext databaseContext;
        public LoginMenuModel(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        [BindProperty]
        public Account InputAccount { get; set; }
        public List<Account> ListAccounts;
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            ListAccounts = databaseContext.Accounts.ToList();
            if (ListAccounts.Count > 0)
            {
                foreach (Account account in ListAccounts)
                {
                    if (account.Username.Equals(InputAccount.Username) && account.Password.Equals(InputAccount.Password))
                    {
                        return RedirectToPage("/Admin/AdminMenu");
                    }
                    return Page();
                }
                return RedirectToPage("/Index");
            }
            return Page();
        }
    }
}
