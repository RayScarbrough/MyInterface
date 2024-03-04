using System;
using System.Collections.Generic;
using System.Linq;

public interface IGame
{
    void AddGame(string title, string genre, int year);
    void RemoveGame(string title);
    void DisplayAllGames();
}

public class GameCollection : IGame
{
    private List<Game> games = new List<Game>();

    public GameCollection()
    {
        // Default games 
        games.Add(new Game { Title = "Escape From Tarkov", Genre = "Extraction Shooter", Year = 2016 });
        games.Add(new Game { Title = "Super Mario Odyssey", Genre = "Platform", Year = 2017 });
        games.Add(new Game { Title = "Minecraft", Genre = "Sandbox", Year = 2011 });
        games.Add(new Game { Title = "The Witcher 3: Wild Hunt", Genre = "Action RPG", Year = 2015 });
    }

    public void AddGame(string title, string genre, int year)
    {
        games.Add(new Game { Title = title, Genre = genre, Year = year });
        Console.WriteLine($"Game '{title}' added successfully.");
    }

    public void RemoveGame(string title)
    {
        var gameToRemove = games.FirstOrDefault(g => g.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        if (gameToRemove != null)
        {
            games.Remove(gameToRemove);
            Console.WriteLine($"Game '{title}' removed successfully.");
        }
        else
        {
            Console.WriteLine("Game not found.");
        }
    }

    public void DisplayAllGames()
    {
        if (games.Any())
        {
            Console.WriteLine("\nAll games in the collection:");
            foreach (var game in games)
            {
                Console.WriteLine($"- {game.Title}, Genre: {game.Genre}, Year: {game.Year}");
            }
        }
        else
        {
            Console.WriteLine("No games in the collection.");
        }
    }

    private class Game
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        var gameCollection = new GameCollection();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nGame Management System");
            Console.WriteLine("1. Add a Game");
            Console.WriteLine("2. Remove a Game");
            Console.WriteLine("3. View All Games");
            Console.WriteLine("4. Exit");
            Console.Write("Select an option: ");

            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.Write("Enter game title: ");
                    var title = Console.ReadLine();
                    Console.Write("Enter game genre: ");
                    var genre = Console.ReadLine();
                    Console.Write("Enter release year: ");
                    int year = int.Parse(Console.ReadLine());
                    gameCollection.AddGame(title, genre, year);
                    break;
                case "2":
                    Console.Write("Enter the title of the game you want to remove: ");
                    var titleToRemove = Console.ReadLine();
                    gameCollection.RemoveGame(titleToRemove);
                    break;
                case "3":
                    gameCollection.DisplayAllGames();
                    break;
                case "4":
                    exit = true;
                    Console.WriteLine("Exiting Game Management System.");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
