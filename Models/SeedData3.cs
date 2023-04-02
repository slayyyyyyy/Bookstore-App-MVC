using Bookstore_App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Bookstore_App.Data;
using System;
using System.Linq;

namespace Bookstore_App.Models;

public static class SeedData3
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new Bookstore_AppContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<Bookstore_AppContext>>()))
        {

            if (context.BoardGames.Any())
            {
                return;
            }
            context.BoardGames.AddRange(
                new BoardGames
                {
                    Name = "Catan",
                    Genre = "Strategy",
                    NoPlayers = "2-4 players",
                    MinAge = 10,
                    Price = 149.99M
                },
                 new BoardGames
                 {
                     Name = "Cards Against Humanity",
                     Genre = "Humor",
                     NoPlayers = "4-6 players or more",
                     MinAge = 18,
                     Price = 99.99M
                 },
                new BoardGames
                {
                    Name = "Activity",
                    Genre = "Cooperative",
                    NoPlayers = "4-9 players",
                    MinAge = 12,
                    Price = 129.99M
                },
                new BoardGames
                {
                    Name = "UNO",
                    Genre = "Card game",
                    NoPlayers = "2-10 players",
                    MinAge = 7,
                    Price = 39.99M
                }
                
            );
            context.SaveChanges();
        }
    }
}