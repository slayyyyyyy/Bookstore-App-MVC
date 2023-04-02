using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore_App.Models
{
    public class BoardGames
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Genre { get; set; }

        public string? NoPlayers { get; set; }

        public int MinAge { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
    }
}