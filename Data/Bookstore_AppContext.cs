using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Bookstore_App.Models;

namespace Bookstore_App.Data
{
    public class Bookstore_AppContext : DbContext
    {
        public Bookstore_AppContext (DbContextOptions<Bookstore_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Bookstore_App.Models.Book> Book { get; set; } = default!;

        public DbSet<Bookstore_App.Models.Album> Album { get; set; } = default!;

        public DbSet<Bookstore_App.Models.BoardGames> BoardGames { get; set; } = default!;

        public DbSet<Bookstore_App.Models.GraphicBook> GraphicBook { get; set; } = default!;
    }
}
