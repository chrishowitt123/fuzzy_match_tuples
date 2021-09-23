using FuzzySharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace importDictFromFile
{
    class Program
    {
        static void Main(string[] args)
        {

            List<string> names1 = new List<string>();

            names1.Add("Dave Adams");
            names1.Add("Steve Bee");
            names1.Add("Daves Adams");
            names1.Add("William Keys");

            var tupleList = new List<Tuple<string, string, int>>();
            for (int i = 0; i < names1.Count - 1; i++)
            {
                for (int j = i + 1; j < names1.Count; j++)
                {
                    var ratio = Fuzz.Ratio(names1[i], names1[j]);


                    var author = new Tuple<string, string, int>(names1[i], names1[j], ratio);
                    tupleList.Add(author);
                }
            }

            var sortedTups = tupleList.OrderByDescending(t => t.Item3).ToList();

            foreach (var t in sortedTups)
            {
                Console.WriteLine(t);
            }
        }
    }
}
