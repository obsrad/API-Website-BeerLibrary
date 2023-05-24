using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeerbliotekWebApplication.Pages.MainPage
{
    public class MainPageModel : PageModel
    {
		DatabaseContext databaseContext;
		public MainPageModel(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		public List<Beer> ListBeers;

		public void OnGet()
		{
			ListBeers = databaseContext.Beers.ToList();
		}
	}
}
