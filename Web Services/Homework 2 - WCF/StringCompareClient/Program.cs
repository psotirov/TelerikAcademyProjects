using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringCompareClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new IISService.StringCountClient();
            string input = "alabalaportokala";
            string substring = "ala";
            Console.WriteLine("{1} is met {2} times in {0}", input, substring, client.GetSubstringCount(input, substring));
            client.Close();
        }
    }
}
