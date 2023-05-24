using BeerbliotekWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BeerAPI
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();

			builder.Services.AddDbContext<DatabaseContext>(
				options => options.UseSqlServer(
					builder.Configuration.GetConnectionString("DefaultConnection"))
					);

			var app = builder.Build();

			// Configure the HTTP request pipeline.

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});


			app.Run();
		}
	}
}