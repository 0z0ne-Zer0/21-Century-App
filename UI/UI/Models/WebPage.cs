using AngleSharp;
using AngleSharp.Dom;

namespace UI.Models
{
    internal class WebPage
    {
        private IDocument _ashDocument;
        private readonly string _url;

        public WebPage(string U)
        {
            _url = U;
        }

        public async Task Load()
        {
            var config = Configuration.Default.WithDefaultLoader();
            var context = BrowsingContext.New(config);
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