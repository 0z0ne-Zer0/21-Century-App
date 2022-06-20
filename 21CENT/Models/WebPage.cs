using AngleSharp;
using AngleSharp.Dom;
using AngleSharp.XPath;
using CefSharp;
using CefSharp.OffScreen;

namespace _21CENT.Models
{
    internal class WebPage
    {
        IBrowsingContext context = BrowsingContext.New(Configuration.Default.WithDefaultLoader());
        private IDocument _ashDocument{get; set;}
        public string _url{get=>context.Active.Url; set=>Load().Wait();}
        ChromiumWebBrowser browser = new ChromiumWebBrowser("www.google.com");

        public WebPage(string U)
        {
            _url = U;
        }

        public async Task Load()
        {
            browser.LoadUrlAsync(_url).Wait();
            _ashDocument = await context.OpenAsync(async c =>{
                var T = await browser.GetTextAsync();
                c.Content(T);
                });
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

        public List<INode> XPathSelector(string xpath)
        {
            return _ashDocument.Body.SelectNodes(xpath);
        }
    }
}