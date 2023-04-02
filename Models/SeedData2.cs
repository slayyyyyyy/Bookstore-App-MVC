using Bookstore_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bookstore_App.Data;
using System;
using System.Linq;

namespace Bookstore_App.Models;

public static class SeedData2
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Bookstore_AppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Bookstore_AppContext>>()))
        {

            if (context.Album.Any())
            {
                return;
            }
            context.Album.AddRange(
                new Album
                {
                    Title = "The Family Jewels",
                    Artist = "MARINA",
                    ReleaseDate = DateTime.Parse("2010-2-15"),
                    Genre = "Alternative Pop",
                    Price = 59.99M
                },
                new Album
                {
                    Title = "Ultraviolence",
                    Artist = "Lana Del Rey",
                    ReleaseDate = DateTime.Parse("2014-6-13"),
                    Genre = "Indie Pop",
                    Price = 49.99M
                },
                new Album
                {
                    Title = "Humbug",
                    Artist = "Arctic Monkeys",
                    ReleaseDate = DateTime.Parse("2009-8-19"),
                    Genre = "Psychedelic Rock",
                    Price = 79.99M
                },
                new Album
                {
                    Title = "The Car",
                    Artist = "Arctic Monkeys",
                    ReleaseDate = DateTime.Parse("2022-10-21"),
                    Genre = "Alternative Rock",
                    Price = 99.99M
                },
                new Album
                {
                    Title= "Ceremonials",
                    Artist= "Florence + the Machine",
                    ReleaseDate=DateTime.Parse("2022-10-28"),
                    Genre="Alternative Pop",
                    Price=74.99M
                }
            );
            context.SaveChanges();
        }
    }
}