using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project
{
    public class Dungeon
    {
        public List<string> appearances { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string id { get; set; }
    }

    public class DungeonRoot
    {
        public bool success { get; set; }
        public int count { get; set; }
        public List<Dungeon> data { get; set; }
    }

}
