using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Final_Project;
using System.Security.Cryptography.X509Certificates;
using Final_Project.API;
using System.Runtime.CompilerServices;

public class ZeldaApiClient
{
    private static readonly HttpClient _httpClient = new HttpClient();

    public static async Task<List<Game>> GetGames()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://zelda.fanapis.com/api/games");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Game>>(responseBody);
    }

    public static async Task<List<Dungeon>> GetDungeons()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://zelda.fanapis.com/api/dungeons");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Dungeon>>(responseBody);
    }

    public static async Task<List<Places>> GetPlaces()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://zelda.fanapis.com/api/places");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Places>>(responseBody);
    }

    public static async Task<List<Root>> GetItems()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://zelda.fanapis.com/api/items");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Root>>(responseBody);
    }

    //public static async Task<List<CharacterRoot>> GetCharacters()
    //{
    //    HttpResponseMessage response = await _httpClient.GetAsync("https://zelda.fanapis.com/api/characters");
    //    response.EnsureSuccessStatusCode();
    //    string responseBody = await response.Content.ReadAsStringAsync();
    //    return JsonConvert.DeserializeObject<List<CharacterRoot>>(responseBody);
    //}


   // Console.Clear();

    public static async Task<List<Monster>> GetMonsters()
    {
        HttpResponseMessage response = await _httpClient.GetAsync("https://zelda.fanapis.com/api/monsters");
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<List<Monster>>(responseBody);
    }
}
class Program
{
    static async Task Main(string[] args)
    {
       
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Welcome to the Legend of Zelda Encyclopedia!");

        bool exit = false;

        while (!exit)
        {
             // Clear console for better user experience
            Console.WriteLine("What would you like to learn about?");
            Console.WriteLine("1. Games");
            Console.WriteLine("2. Dungeons");
            Console.WriteLine("3. Places");
            Console.WriteLine("4. Items");
            Console.WriteLine("5. Characters");
            Console.WriteLine("6. Monsters");
            Console.WriteLine("0. Exit");

            Console.Write("Enter your choice: ");
            string userInput = Console.ReadLine().Trim();

            switch (userInput)
            {
                case "1":
                    await DisplayItems<Game>("Games", ZeldaApiClient.GetGames);
                    break;
                case "2":
                    await DisplayItems<Dungeon>("Dungeons", ZeldaApiClient.GetDungeons);
                    break;
                case "3":
                    await DisplayItems<Places>("Places", ZeldaApiClient.GetPlaces);
                    break;
                case "4":
                    await DisplayItems<Root>("Items", ZeldaApiClient.GetItems);
                    break;
                case "5":
                    //await DisplayItems<CharacterRoot>("Characters", ZeldaApiClient.GetCharacters);
                    CharacterMethods.GenerateCharacters();
                   
                    break;
                case "6":
                    await DisplayItems<Monster>("Monsters", ZeldaApiClient.GetMonsters);
                    break;
                case "0":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please enter a valid option.");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }

        Console.WriteLine("Exiting Legend of Zelda Encyclopedia. Press any key to close...");
        Console.ReadKey();
    }

    static async Task DisplayItems<T>(string category, Func<Task<List<T>>> fetchData)
    {
        try
        {
            List<T> items = await fetchData();

            Console.Clear();
            Console.WriteLine($"List of {category}:");
            for (int i = 0; i < items.Count; i++)
            {
                // Assuming each item has a 'name' property
                string itemName = (string)items[i].GetType().GetProperty("name").GetValue(items[i]);
                Console.WriteLine($"{i + 1}. {itemName}");
            }

            Console.WriteLine();
            Console.WriteLine("Enter the number of the item you want to learn more about,");
            Console.WriteLine("or enter '0' to go back:");

            string userInput = Console.ReadLine().Trim();

            if (int.TryParse(userInput, out int selectedIndex) && selectedIndex >= 1 && selectedIndex <= items.Count)
            {
                T selectedItem = items[selectedIndex - 1];
                Console.WriteLine();
                Console.WriteLine($"Details of {category.TrimEnd('s')}:");
                foreach (var prop in selectedItem.GetType().GetProperties())
                {
                    Console.WriteLine($"{prop.Name}: {prop.GetValue(selectedItem)}");
                }
            }
            else if (userInput == "0")
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}