using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XMLProcesses;
using NLog;


namespace ConsoleTest
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            string sourcePath = @"SourceTextFile.txt";
            string outputPath = @"OutputXmlFile.xml";
            string line = String.Empty;
            string outputXml = string.Empty;
            using (StreamReader sr = new StreamReader(sourcePath, System.Text.Encoding.Default))
            {
                XDocument xDoc = UriToXmlParser.Parse(sr);
                xDoc.Save(outputPath);
            }

            Console.ReadLine();
        }
    }
}
