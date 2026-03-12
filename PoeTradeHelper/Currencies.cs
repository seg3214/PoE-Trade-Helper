using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Xml;
namespace PoeTradeHelper
{
    public static class Currencies
    {
        public struct Curr
        {
            public string Name;
            public int stacksize;
            public Image Image;
        }
        public static List<Curr> CurrencyList = new List<Curr>();
        private static readonly string filename = "XMLFile1.xml";

        public static void Initialize(string assetdir)
        {
            XmlDocument xml = new XmlDocument();
            string filepath = Path.GetFullPath(Path.Combine(assetdir, filename));
            xml.Load(filepath);
            XmlNodeList xnList = xml.SelectNodes("/Currencies/Currency");
            foreach (XmlNode xn in xnList)
            {
                Curr cc = new Curr
                {
                    stacksize = Int32.Parse(xn["Stacksize"].InnerText),
                    Name = xn["Name"].InnerText
                };
                string imagefile = Path.GetFullPath(Path.Combine(assetdir, @"images\" + xn["Image"].InnerText));
                //Debug.WriteLine($"{imagefile}");
                cc.Image = Image.FromFile(imagefile);
                //Console.WriteLine("Name: {0} {1} {2}", cc.stacksize, cc.Name, cc.Image);
                CurrencyList.Add(cc);
            }
        }
    }
}
