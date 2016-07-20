using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.ServiceModel.Syndication;

namespace RssReader
{
    public enum RssMode
    {
        Topic,
        KeyWord
    }

    public class GoogleRssReader : AbstractRssReader
    {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="key"></param>
        public GoogleRssReader(RssMode rssMode, string key) : base(key)
        {
            baseUrl = "http://news.google.com/news?hl=ja&ned=us&ie=UTF-8&oe=UTF-8&output=rss&";
            string param = string.Empty;

            switch (rssMode)
            {
                case RssMode.Topic:
                    param = string.Format("{0}={1}", "topic", key);
                    break;
                case RssMode.KeyWord:
                    param = string.Format("{0}={1}", "p", key);
                    break;
            }

            requestUrl = baseUrl + param;
        }

        /// <summary>
        /// GoogleRssを取得
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
                    /* GoogleRssはカテゴリが存在しないため取得しない                    
                    item.Category = syndItem.Categories.ToString();
                    */
                    article.PublishedData = syndItem.PublishDate.ToString();
                    articles.Add(article);                    
                }
                
            }

            return articles;
        }

    }
}
