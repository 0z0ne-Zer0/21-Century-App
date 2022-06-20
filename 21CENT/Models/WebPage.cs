using AngleSharp;
using AngleSharp.Dom;

namespace _21CENT.Models
{
    internal class WebPage
    {
        public IDocument _ashDocument;
        private string _url;
        public string text;


        public WebPage(string U)
        {
            _url = U;
        }

        public async Task Load()
        {
            IBrowsingContext context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
            _ashDocument = await context.OpenAsync(_url);
        }

        public IHtmlCollection<IElement> QuerySelector(string query)
        {
            return _ashDocument.QuerySelectorAll(query);
        }

        public IHtmlCollection<IElement> FindByClass(string name)
        {
            return _ashDocument.GetElementsByClassName(name);
        }

        public IHtmlCollection<IElement> FindByTag(string name)
        {
            return _ashDocument.GetElementsByTagName(name);
        }
    }
}