using Bookstore_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bookstore_App.Data;
using System;
using System.Linq;

namespace Bookstore_App.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Bookstore_AppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Bookstore_AppContext>>()))
        {
            
            if (context.Book.Any())
            {
                return;   
            }
            context.Book.AddRange(
                new Book
                {
                    Title = "Solitaire",
                    Author = "Alice Oseman",
                    ReleaseDate = DateTime.Parse("2014-7-31"),
                    Genre = "Young Adult",
                    Price = 24.99M
                },
                new Book
                {
                    Title = "Radio Silence",
                    Author = "Alice Oseman",
                    ReleaseDate = DateTime.Parse("2016-2-25"),
                    Genre = "Contemporary",
                    Price = 24.99M
                },
                new Book
                {
                    Title = "Poezii",
                    Author = "Mihai Eminescu",
                    ReleaseDate = DateTime.Parse("1885-2-23"),
                    Genre = "Poetry",
                    Price = 9.99M
                },
                new Book
                {
                    Title = "Crime and Punishment",
                    Author = "Fyodor Dostoevsky",
                    ReleaseDate = DateTime.Parse("1886-4-15"),
                    Genre = "Literary Fiction",
                    Price = 34.99M
                }
            );
            context.SaveChanges();
        }
    }
}