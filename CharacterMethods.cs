using Final_Project.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class CharacterMethods
    {
        public static async Task<CharacterRoot> GetCharacters(string? url)
        {
            var client = new HttpClient();
            var character = new CharacterRoot();

            var charactersAPIService = new CharacterAPIService("https://zelda.fanapis.com/api/characters", client);
            var response = await charactersAPIService.GetApiResponse<CharacterRoot>();

            return response;

        }

        public static async void GenerateCharacters() 
        {

            
        
        }
    }
}
