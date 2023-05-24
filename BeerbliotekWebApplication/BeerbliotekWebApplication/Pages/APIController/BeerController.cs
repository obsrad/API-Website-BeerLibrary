using BeerbliotekWebApplication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.PortableExecutable;

namespace BeerbliotekWebApplication.Pages.API
{
	[ApiController]
	[Route("[controller]")]
	public class BeerController : ControllerBase
	{
		private readonly DatabaseContext _databaseContext;
		private bool BeerExists;

		public BeerController(DatabaseContext context)
		{
			_databaseContext = context;
		}


		// GET URL: /beer
		[HttpGet]
		//ActionResult returns a (IEnumerable) collection of Beer objects.
		//IEnumerable returns that collection without having to put them in a list.
		public async Task<ActionResult<IEnumerable<Beer>>> GetBeers()
		{
			return await _databaseContext.Beers.ToListAsync();
		}


		// GET URL: /beer/5
		[HttpGet("{id}")]
		public async Task<ActionResult<Beer>> GetBeer(int id)
		{
			var beer = await _databaseContext.Beers.FindAsync(id);

			if (beer == null)
			{
				return NotFound();
			}

			return beer;
		}

		// POST URL: /beer
		[HttpPost]
		public async Task<ActionResult<Beer>> PostBeer(Beer beer)
		{
			_databaseContext.Beers.Add(beer);
			await _databaseContext.SaveChangesAsync();

			return CreatedAtAction(nameof(GetBeer), new { id = beer.Id }, beer);
		}


		// PUT URL: /beer/5
		[HttpPut("{id}")]
		public async Task<IActionResult> PutBeer(int id, Beer beer)
		{
			if (id != beer.Id)
			{
				return BadRequest();
			}

			var existingBeer = await _databaseContext.Beers.FindAsync(id);
			if (existingBeer == null)
			{
				return NotFound();
			}

			_databaseContext.Entry(existingBeer).CurrentValues.SetValues(beer);

			try
			{
				await _databaseContext.SaveChangesAsync();
			}

			//if multiple users or processes try to update the db at the same time
			//prevent that from happening
			catch (DbUpdateConcurrencyException)
			{
				return StatusCode(500);
			}

			return NoContent();
		}


		// DELETE URL: /beer/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteBeer(int id)
		{
			var beer = await _databaseContext.Beers.FindAsync(id);
			if (beer == null)
			{
				return NotFound();
			}

			_databaseContext.Beers.Remove(beer);
			await _databaseContext.SaveChangesAsync();

			return NoContent();
		}
	}
}