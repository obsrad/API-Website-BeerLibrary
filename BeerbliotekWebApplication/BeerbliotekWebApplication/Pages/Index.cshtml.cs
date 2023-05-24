using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BeerbliotekWebApplication.Pages
{
    public class IndexModel : PageModel
    {
        DatabaseContext databaseContext;
        public IndexModel(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void OnGet()
        {
            //If there is not any data. Create some example data
            if(databaseContext.Beers.ToList().Count == 0)
            { 
                databaseContext.Beers.Add(new Beer("Staropramen", 5, 17.90, 330, "Ljus Lager", "Tjeckien"));
                databaseContext.Beers.Add(new Beer("Guinness", 4.2, 25.50, 440, "Porter och Stout", "Irland"));
                databaseContext.Beers.Add(new Beer("Mariestads Export", 5.3, 13.50, 330, "Ljus Lager", "Sverige"));
                databaseContext.Beers.Add(new Beer("Kona Brewing", 4.4, 23.90, 355, "Ale", "USA"));
                databaseContext.Beers.Add(new Beer("Corona Extra", 4.5, 19.90, 355, "Ljus Lager", "Mexiko"));
                databaseContext.Beers.Add(new Beer("Brooklyn", 5.5, 17.90, 330, "Ale", "Sverige")); 
            }
        
            if(databaseContext.Accounts.ToList().Count == 0)
            {
                Account adminAccount = new Account() { Username = "admin", Password = "admin123" };
                databaseContext.Accounts.Add(adminAccount);
            }
            databaseContext.SaveChanges();
        }
    }
}