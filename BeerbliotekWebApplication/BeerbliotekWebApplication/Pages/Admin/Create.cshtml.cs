using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;

namespace BeerbliotekWebApplication.Pages.Admin
{
    public class CreateModel : PageModel
    {
        DatabaseContext databaseContext;
        public CreateModel(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [BindProperty]
        public Beer Beer { get; set; }

		public void OnGet()
        {
        }

		public ActionResult OnPost()
		{
            if (ModelState.IsValid)
            {
                databaseContext.Beers.Add(Beer);
                databaseContext.SaveChanges();
                return RedirectToPage("/Admin/AdminMenu");
            }
            return Page();
		}
	}
}
