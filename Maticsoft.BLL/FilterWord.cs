using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace Maticsoft.BLL
{
    public static class FilterWord
    {
        public static List<string> Words
        {
            get
            {
                List<string> wordlist = new List<string>();
                string CacheKey = "FilterWord";
                object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
                if (objModel == null)
                {
                    try
                    {
                        string configPath = HttpContext.Current.Request.MapPath("/Config/FilterWord.txt");
                        string[] words = File.ReadAllLines(configPath);
                        if (words != null && words.Length > 0)
                        {
                            foreach (string s in words)
                            {
                                wordlist.Add(s);
                            }
                            int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                            Maticsoft.Common.DataCache.SetCache(CacheKey, wordlist, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                        }
                    }
                    catch
                    {
                    }
                }
                else
                {
                    wordlist = (List<string>)objModel;
                }
                return wordlist;
            }
        }
    }
}