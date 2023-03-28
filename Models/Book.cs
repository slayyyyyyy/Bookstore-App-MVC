using System.ComponentModel.DataAnnotations;

namespace Bookstore_App.Models
{
    public class Book
    {  
        public int Id { get; set; }
        public string? Title { get; set; }
        [DataType(DataType.Date)]
        public string? Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public decimal Price { get; set; }
    }
}
