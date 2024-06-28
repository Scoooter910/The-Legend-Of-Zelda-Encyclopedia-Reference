using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project
{
    public class Places
    {
        public List<string> appearances { get; set; }
        public List<string> inhabitants { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string id { get; set; }
    }

    public class Place
    {
        public bool success { get; set; }
        public int count { get; set; }
        public List<Places> data { get; set; }
    }
}
