using System.ComponentModel.DataAnnotations;

namespace BeerbliotekWebApplication.Models
{
    public class Beer
    {
		[Key]
		public int Id { get; set; }
		[MaxLength(45)]
		public string Name { get; set; }
		public double Alcohol { get; set; }
		public double Price { get; set; }
		public int Volume { get; set; }
		[MaxLength(45)]
		public string Type { get; set; }
		[MaxLength(45)]
		public string Country { get; set; }
		public Beer(string name, double alcohol, double price, int volume, string type, string country)
		{
			Name = name;
			Alcohol = alcohol;
			Price = price;
			Volume = volume;
			Type = type;
			Country = country;
		}
		public Beer()
		{

		}
	}
}
