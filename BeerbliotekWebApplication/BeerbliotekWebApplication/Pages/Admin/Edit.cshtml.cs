using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace BeerbliotekWebApplication.Pages.Admin
{
    public class EditModel : PageModel
    {
		DatabaseContext databaseContext;
		public EditModel(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		[BindProperty]
		public Beer Beer { get; set; }

		public void OnGet(int id)
		{
			Beer = databaseContext.Beers.Find(id);
		}

		public ActionResult OnPost()
		{
			if (ModelState.IsValid)
			{
				Beer updateBeer = databaseContext.Beers.Find(Beer.Id);

				updateBeer.Name = Beer.Name;
				updateBeer.Alcohol = Beer.Alcohol;
				updateBeer.Price = Beer.Price;
				updateBeer.Volume = Beer.Volume;
				updateBeer.Type = Beer.Type;
				updateBeer.Country = Beer.Country;

				databaseContext.SaveChanges();
				return RedirectToPage("/Admin/AdminMenu");
			}
			return Page();
		}
	}
}
