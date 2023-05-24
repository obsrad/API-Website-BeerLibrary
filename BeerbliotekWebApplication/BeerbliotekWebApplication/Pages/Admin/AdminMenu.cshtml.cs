using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace BeerbliotekWebApplication.Pages.Admin
{
    public class AdminMenuModel : PageModel
    {
        DatabaseContext databaseContext;
        public AdminMenuModel(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public List<Beer> ListBeers;

        public void OnGet()
        {
            ListBeers = databaseContext.Beers.ToList();
        }

        public ActionResult OnGetDelete(int? id)
        {
            if (id != null)
            {
                var data = (from beer in databaseContext.Beers
                            where beer.Id == id
                            select beer).SingleOrDefault();
                databaseContext.Remove(data);
                databaseContext.SaveChanges();
            }
            return RedirectToPage("/Admin/AdminMenu");
        }
    }
}
