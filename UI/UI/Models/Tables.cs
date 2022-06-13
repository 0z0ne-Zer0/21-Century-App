using System.Xml;

namespace UI.Models
{
    public class MainWebPage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }

    public class SubWebPage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int Pages { get; set; }
        public int PId { get; set; }
    }

    public class CatalogItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public bool IsInStock { get; set; }
        public bool IsDiscount { get; set; }
        public double Price { get; set; }
        public double OldPrice { get; set; }
        public XmlDocument Props { get; set; }
        public int PId { get; set; }
    }
}