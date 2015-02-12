using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTM23DS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in System.IO.Directory.GetFiles(".","*.dtm", System.IO.SearchOption.AllDirectories))
            {
                Console.WriteLine("parsing:{0}", item);
                ArmadaTank2ThreedDS.DTM23DSParser.Parse(item);
            }
            Console.WriteLine("Done");
            Console.ReadKey(false);
        }
    }
}
