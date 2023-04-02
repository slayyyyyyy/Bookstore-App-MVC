using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore_App.Models
{
    public class GraphicBook
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
 
        public string? Type { get; set; }
        public string? Genre { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}
