using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RssReader;

namespace TestRssReader
{
    class Program
    {
        static void Main(string[] args)
        {
            RssReader.GoogleRssReader googleRssReader = new RssReader.GoogleRssReader(RssMode.KeyWord, "阪神");
            googleRssReader.getArticles();
        }
    }
}
