using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ArmadaTank.DTMParser.Result;
using ArmadaTank.DTMParser;

namespace DTM23DS
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var item in System.IO.Directory.GetFiles(".","*.dtm", System.IO.SearchOption.AllDirectories))
            {
                Console.WriteLine("parsing:{0}", item);
                var sourceCode = File.ReadAllText(item);
                var lexi = new ArmadaTank.DTMParser.LexicalAnalyzerDTM(sourceCode);
                var tokens = lexi.Analyze();
                var parser = new ArmadaTank.DTMParser.LL1SyntaxParserDTM(tokens);
                var tree = parser.Parse();
                var dtmObj = tree.GetModel();
                var bmp = dtmObj.GenerateBitmap(500,500);
                bmp.RotateFlip(System.Drawing.RotateFlipType.RotateNoneFlipY);
                bmp.Save(item + ".bmp");
                ArmadaTank2ThreedDS.DTM23DSParser.Parse(item);
            }
            Console.WriteLine("Done");
            Console.ReadKey(false);
        }
    }
}
