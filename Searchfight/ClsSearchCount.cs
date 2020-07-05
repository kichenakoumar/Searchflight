using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Configuration;


namespace Searchfight
{
    class ClsSearchCount : ClsConfig
    {
        
        public static List<ClsConfig> newConfig = new List<ClsConfig>();
        public static List<string> winnerList = new List<string>();
        public static void SearchFight(string[] searchTerms)
        {
            try
            {
            ClsReadSetting.ReadAllSettings();
            foreach (var element in searchTerms)
            {
                Console.WriteLine(element + ":");
                int istartcount = 0;
                string printtxt = string.Empty;
                foreach (var crs in newConfig)
                {
                    
                    Task<long> Count = searchCount(crs.sUrl + element, "\"" + crs.sXpath + "\">");
                    Console.Write(crs.sSrchEngine + " " + "Search count: " + Count.Result);
                    Console.Write(Environment.NewLine);
                    if (istartcount == 0)
                    {
                        printtxt = crs.sSrchEngine + "" + "winner:" + " " + element;
                        istartcount = Convert.ToInt32(Count.Result);
                    }
                    if (Count.Result > istartcount)
                        printtxt = crs.sSrchEngine + "" + "winner:" + " " + element;

                }
                if (istartcount != 0)
                    winnerList.Add(printtxt);
                Console.Write(Environment.NewLine);

            }
            for (int i = 0; i < winnerList.Count; i++)
            {
                Console.WriteLine(winnerList[i]);
            }
        }

            catch (Exception e) { throw e; }
        }

        //public static long searchCount(string url, string resultTag)
        static async Task<long> searchCount(string url, string sresult)
        {
            
            using (Stream resultStream = (new WebClient()).OpenRead(url))
            {
                using (StreamReader streamReader = new StreamReader(resultStream))
                {
                    string sline;

                    while ((sline = streamReader.ReadLine()) != null)
                    {
                        if (!sline.Contains(sresult))
                            continue;
                        try
                        {
                            await streamReader.ReadToEndAsync(); 
                            string sfirstSplit = sline.Split(new String[] { sresult }, StringSplitOptions.None)[1];
                            string ssecondSplit = sfirstSplit.Split('<')[0];
                            string snumber = Regex.Replace(ssecondSplit, "[^\\d]", "");
                            return long.Parse(snumber);
                        }
                        catch (Exception e) { throw e; }
                        finally
                        {
                            GC.SuppressFinalize(0);
                        }

                    }

                }
            }
            return 0;
             
           
        }

    }
}
