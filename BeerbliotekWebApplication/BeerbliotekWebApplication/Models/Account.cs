using System.ComponentModel.DataAnnotations;

namespace BeerbliotekWebApplication.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(45)]
        public string Username { get; set; }
        [MaxLength(45)]
        public string Password { get; set; }
    }
}
