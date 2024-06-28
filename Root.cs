using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Final_Project
{
    public class Root
    {
        public bool success { get; set; }
        public int count { get; set; }
        public List<Datum> data { get; set; }
    }
}
