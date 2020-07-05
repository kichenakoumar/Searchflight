using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Searchfight
{
    class Program
    {
        public static List<ClsConfig> newConfig = new List<ClsConfig>();

        static void Main(string[] args)
        {
            try
            {
                //Regex to support quotation marks to allow searching for terms with spaces(e.g. .Net c# “java script”)
                args = Regex.Matches(Console.ReadLine(), "[^\\s\"']+|\"([^\"]*)\"|'([^']*)'").Cast<Match>
                ().Select(iMatch => iMatch.Value.Replace("\"", "").Replace("'", "")).ToArray();
                ClsSearchCount.SearchFight(args);
                Console.ReadLine();
            }
            catch (Exception e) { throw e; }

        }



    }
}
