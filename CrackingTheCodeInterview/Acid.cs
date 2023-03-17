    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace ConsoleApplication5
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class Solution
    {

        static string acidNaming(string acid_name)
        {
            string name = "not an acid";
            Regex nonmet = new Regex(@"(hydro)(\w+)(ic)");
            Match match1 = nonmet.Match(acid_name);
            if (match1.Success)
            {
                name = "non-metal acid  ";
            }

           
            else
            {
                Regex poly = new Regex(@"(\w+)(ic)");
                Match match = poly.Match(acid_name);
                if (match.Success)
                {
                    name = "polyatomic acid";
                }
            } 

            return name;
        }
        static string acidName(string acid_name)
        {
            string name = "not an acid";
            if (acid_name != null && acid_name != string.Empty)
            {
                int legth = acid_name.Length;
                if (acid_name.Substring(0, 5) == "hydro" && acid_name.Substring(legth - 2, 2) == "ic") name = "non-metal acid";
                else if (acid_name.Substring(legth - 2, 2) == "ic") name = "polyatomic acid";
            }
            return name;

        }
        //static void Main(String[] args)
        //{
        //    int n = Convert.ToInt32(Console.ReadLine());
        //    for (int a0 = 0; a0 < n; a0++)
        //    {
        //        string acid_name = Console.ReadLine();
        //        string result = acidName(acid_name);
        //        Console.WriteLine(result);
        //    }
        //    Console.ReadLine();
        //}
    }

}
