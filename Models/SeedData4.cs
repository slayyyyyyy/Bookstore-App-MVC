using Bookstore_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bookstore_App.Data;
using System;
using System.Linq;

namespace Bookstore_App.Models;

public static class SeedData4
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Bookstore_AppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Bookstore_AppContext>>()))
        {

            if (context.GraphicBook.Any())
            {
                return;
            }
            context.GraphicBook.AddRange(
                new GraphicBook
                {
                    Title = "Jujutsu Kaisen vol. 0",
                    Author = "Gege Akutami",
                    Type= "Manga",
                    Genre = "Shounen",
                    Price = 59.99M
                },
                new GraphicBook
                {
                    Title = "Chainsaw Man vol. 5",
                    Author = "Tatsuki Fujimoto",
                    Type = "Manga",
                    Genre = "Shounen",
                    Price = 59.99M
                },
                 new GraphicBook
                 {
                     Title = "Anya's Ghost",
                     Author = "Vera Brosgol",
                     Type = "Graphic Novel",
                     Genre = "Coming-of-age",
                     Price = 44.99M
                 },
                 new GraphicBook
                 {
                     Title = "Sandman vol. 3",
                     Author = "Neil Gaiman",
                     Type = "Comic",
                     Genre = "Fantasy",
                     Price = 79.99M
                 },
                  new GraphicBook
                  {
                      Title = "Horimiya vol. 1",
                      Author = "Daisuke Hagiwara",
                      Type = "Manga",
                      Genre = "Shojo",
                      Price = 59.99M
                  }
            );
            context.SaveChanges();
        }
    }
}