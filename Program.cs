using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Final_Project;

public class ZeldaApiClient
{
    private static readonly HttpClient _httpClient = new HttpClient();
    public static async Task<List<Datum>> GetAllGames()
    {

        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync("https://zelda.fanapis.com/api/games");

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                Root apiResponse = JsonConvert.DeserializeObject<Root>(json);

                if (apiResponse != null && apiResponse.success && apiResponse.data != null)
                {
                    return apiResponse.data;
                }
                else
                {
                    throw new Exception("No Zelda games found or API response is invalid.");
                }
            }
            else
            {
                throw new Exception($"Failed to retrieve games: {response.StatusCode}");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Error fetching games: {ex.Message}", ex);
        }
    }
}

public class Program
{
    static async Task Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to the Zelda Game Encyclopedia!");
        Console.WriteLine("Fetching list of Zelda games...");

        try
        {
            List<Datum> games = await ZeldaApiClient.GetAllGames();

            if (games != null && games.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine("List of Zelda Games:");

                // Displaying game titles for reference
                foreach (var game in games)
                {
                    Console.WriteLine($"- {game.name}");
                }

                // Prompt user for input
                Console.Write("Enter the title of the Zelda game you want to know more about: ");
                string userInput = Console.ReadLine().Trim(); // Trim to remove leading/trailing whitespace
                Console.WriteLine($"User entered: '{userInput}'");

                // Debug: Print out all game names for verification
                Console.WriteLine("Available game names:");
                foreach (var game in games)
                {
                    Console.WriteLine($"- {game.name}");
                }

                // Find the game based on user input (case-insensitive)
                Datum chosenGame = games.Find(g => g.name.Equals(userInput, StringComparison.OrdinalIgnoreCase));

                if (chosenGame != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Title: {chosenGame.name}");
                    Console.WriteLine($"Description: {chosenGame.description}");
                    Console.WriteLine($"Developer: {chosenGame.developer}");
                    Console.WriteLine($"Publisher: {chosenGame.publisher}");
                    Console.WriteLine($"Released Date: {chosenGame.released_date}");
                    // Display more details if available
                }
                else
                {
                    Console.WriteLine($"Zelda game '{userInput}' not found.");
                }
            }
            else
            {
                Console.WriteLine("No Zelda games found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
