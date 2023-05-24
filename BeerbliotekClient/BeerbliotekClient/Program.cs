using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace BeerbliotekClient
{
    public class Program
    {
		static async Task Main(string[] args)
		{
			var httpClient = new HttpClient();

			while (true)
			{
				Console.WriteLine("BeerAPI Menu:");
				Console.WriteLine("1. Create a new beer");
				Console.WriteLine("2. Read all beers");
				Console.WriteLine("3. Read beer by ID");
				Console.WriteLine("4. Update a beer");
				Console.WriteLine("5. Delete a beer");
				Console.WriteLine("6. Exit");

				Console.Write("Enter a menu number: ");
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						await CreateNewBeer(httpClient);
						break;
					case "2":
						await ShowAllBeers(httpClient);
						break;
					case "3":
						Console.Write("Enter beer id: ");
						int id = int.Parse(Console.ReadLine());
						await ShowBeerById(httpClient, id);
						break;
					case "4":
						await UpdateBeer(httpClient);
						break;
					case "5":
						await DeleteBeer(httpClient);
						break;
					case "6":
						Console.WriteLine("Bye bye!");
						return;
					default:
						Console.WriteLine("Menu number not found.");
						break;
				}
			}
		}

		private static async Task CreateNewBeer(HttpClient httpClient)
		{
			Console.Write("Enter beer name: ");
			string name = Console.ReadLine();

			Console.Write("Enter beer alcohol: ");
			float alcohol = float.Parse(Console.ReadLine());

			Console.Write("Enter beer price: ");
			float price = float.Parse(Console.ReadLine());

			Console.Write("Enter beer volume: ");
			int volume = int.Parse(Console.ReadLine());

			Console.Write("Enter beer type: ");
			string type = Console.ReadLine();

			Console.Write("Enter beer country: ");
			string country = Console.ReadLine();

			var beer = new Beer
			{
				Name = name,
				Alcohol = alcohol,
				Price = price,
				Volume = volume,
				Type = type,
				Country = country
			};

			var beerJson = JsonConvert.SerializeObject(beer);
			var content = new StringContent(beerJson, Encoding.UTF8, "application/json");
			var response = await httpClient.PostAsync("https://localhost:7257/beer", content);
			response.EnsureSuccessStatusCode();

			Console.Clear();
			Console.WriteLine("Beer created.");
			Console.WriteLine("");
		}


		private static async Task ShowAllBeers(HttpClient httpClient)
		{
			var response = await httpClient.GetAsync("https://localhost:7257/beer");
			response.EnsureSuccessStatusCode();

			var responseJson = await response.Content.ReadAsStringAsync();
			var beers = JsonConvert.DeserializeObject<List<Beer>>(responseJson);

			Console.Clear();

			foreach (var beer in beers)
			{
				Console.WriteLine($"Beer id: {beer.Id}, name: {beer.Name}, alcohol: {beer.Alcohol}," +
					$" price: {beer.Price}, volume: {beer.Volume}, type: {beer.Type}, country: {beer.Country}");
			}

			Console.WriteLine("");
		}



		private static async Task ShowBeerById(HttpClient httpClient, int id)
		{
			var response = await httpClient.GetAsync($"https://localhost:7257/beer/{id}");
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				Console.WriteLine("Beer not found.");
				return;
			}
			response.EnsureSuccessStatusCode();

			var responseJson = await response.Content.ReadAsStringAsync();
			var beer = JsonConvert.DeserializeObject<Beer>(responseJson);

			Console.Clear();

			Console.WriteLine($"Beer found: {beer.Id}, name: {beer.Name}, alcohol: {beer.Alcohol}," +
				$" price: {beer.Price}, volume: {beer.Volume}, type: {beer.Type}, country: {beer.Country}");
			Console.WriteLine("");
		}



		private static async Task UpdateBeer(HttpClient httpClient)
		{
			Console.Write("Enter beer ID: ");
			var id = int.Parse(Console.ReadLine());

			//Check if the beer exists
			var response = await httpClient.GetAsync($"https://localhost:7257/beer/{id}");
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				Console.WriteLine("Beer not found.");
				return;
			}
			response.EnsureSuccessStatusCode();

			var responseJson = await response.Content.ReadAsStringAsync();
			var beer = JsonConvert.DeserializeObject<Beer>(responseJson);

			Console.WriteLine($"Beer found: {beer.Id}, name: {beer.Name}, alcohol: {beer.Alcohol}," +
							  $" price: {beer.Price}, volume: {beer.Volume}, type: {beer.Type}, country: {beer.Country}");
			Console.WriteLine("");

			//Get the updated beer data from the user
			Console.Write("Enter new name: ");
			var name = Console.ReadLine();

			Console.Write("Enter new alcohol percentage: ");
			var alcohol = float.Parse(Console.ReadLine());

			Console.Write("Enter new price: ");
			var price = float.Parse(Console.ReadLine());

			Console.Write("Enter new volume: ");
			var volume = int.Parse(Console.ReadLine());

			Console.Write("Enter new type: ");
			var type = Console.ReadLine();

			Console.Write("Enter new country: ");
			var country = Console.ReadLine();

			//Update the beer
			var updatedBeer = new Beer
			{
				Id = id,
				Name = name,
				Alcohol = alcohol,
				Price = price,
				Volume = volume,
				Type = type,
				Country = country
			};
			var json = JsonConvert.SerializeObject(updatedBeer);
			var content = new StringContent(json, Encoding.UTF8, "application/json");
			response = await httpClient.PutAsync($"https://localhost:7257/beer/{id}", content);
			response.EnsureSuccessStatusCode();

			Console.Clear();

			Console.WriteLine($"Beer {id} updated successfully.");
			Console.WriteLine($"New beer: {updatedBeer.Id}, name: {updatedBeer.Name}, alcohol: {updatedBeer.Alcohol}," +
				$" price: {updatedBeer.Price}, volume: {updatedBeer.Volume}, type: {updatedBeer.Type}, country: {updatedBeer.Country}");

			Console.WriteLine("");
		}


		private static async Task DeleteBeer(HttpClient httpClient)
		{
			Console.Write("Enter beer ID: ");
			var id = int.Parse(Console.ReadLine());

			//Check if the beer exists
			var response = await httpClient.GetAsync($"https://localhost:7257/beer/{id}");
			if (response.StatusCode == HttpStatusCode.NotFound)
			{
				Console.WriteLine("Beer not found.");
				return;
			}
			response.EnsureSuccessStatusCode();

			Console.Clear();

			//Delete the beer
			response = await httpClient.DeleteAsync($"https://localhost:7257/beer/{id}");
			response.EnsureSuccessStatusCode();

			Console.WriteLine($"Beer {id} deleted successfully.");

			Console.WriteLine("");
		}
	}
}