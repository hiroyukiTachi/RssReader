using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ServiceModel.Syndication;

namespace RssReader
{
    /// <summary>
    /// RSSリーダー抽象クラス
    /// </summary>
    abstract public class AbstractRssReader
    {
        protected string key;
        protected string baseUrl;
        protected string requestUrl;

        public AbstractRssReader(string key)
        {
            this.key = key;
        }

        public abstract IEnumerable<Article> getArticles();        

    }
}
