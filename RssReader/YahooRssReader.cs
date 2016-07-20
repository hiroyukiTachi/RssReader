using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.ServiceModel.Syndication;

namespace RssReader
{
    public class YahooRssReader : AbstractRssReader
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="key"></param>
        public YahooRssReader(string key) : base(key)
        {
            baseUrl = "http://headlines.yahoo.co.jp/rss/";
            string param = string.Format("{0}.{1}", key, "xml");
            requestUrl = baseUrl + param;
        }

        /// <summary>
        /// YachooRssを取得
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<Article> getArticles()
        {            
            IList<Article> articles = new List<Article>();

            using (XmlReader rd = XmlReader.Create(requestUrl))
            {
                SyndicationFeed feed = SyndicationFeed.Load(rd);

                foreach (SyndicationItem syndItem in feed.Items)
                {
                    Article article = new Article();
                    article.Title = syndItem.Title.Text;
                    article.Link = syndItem.Links[0].Uri.ToString();
                    article.Category = syndItem.Categories.ToString();                    
                    article.PublishedData = syndItem.PublishDate.ToString();
                    articles.Add(article);
                }

            }

            return articles;
        }

    }
}
