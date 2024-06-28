using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project.API
{
    internal class CharacterAPIService : APIService
    {
        public CharacterAPIService(string? url, HttpClient httpClient) : base(url, httpClient) 
        {
        
        }

    }
}
