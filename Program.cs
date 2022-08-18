using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp2
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Segregator segregator = new Segregator();
            List<int> data = new List<int>() {3,4,5,6,8,7,8,3,13,14,15,16,17,18,13,22,23};
            Debug.Assert(segregator.find_data(data) == "{3-8: 8} {13-18: 7} {22-23: 2} ");            
            
            List<int> data1 = new List<int>() {100,110,120,101,111,121,102,112,122,150};
            Debug.Assert(segregator.find_data(data1) == "{100-102, 3} {110-112, 3} {120-122, 4} ");
            

        }
    }
}
