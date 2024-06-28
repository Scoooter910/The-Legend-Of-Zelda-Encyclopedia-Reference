using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Project
{
    public class Game
    {
        public string name { get; set; }
        public string description { get; set; }
        public string developer { get; set; }
        public string publisher { get; set; }
        public string released_date { get; set; }
        public string id { get; set; }
    }

    public class GamesRoot
    {
        public bool success { get; set; }
        public int count { get; set; }
        public List<Game> data { get; set; }
    }
}
