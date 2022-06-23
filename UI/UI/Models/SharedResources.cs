using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Post = UI.Services.PostgreSQL;
using Lite = UI.Services.SQLite;

namespace UI.Models
{
    internal class SharedResources
    {
        public static List<Post.CatalogItem> PostCart { get; set; } = new List<Post.CatalogItem>();
        public static List<Lite.CatalogItem> LiteCart { get; set; } = new List<Lite.CatalogItem>();
        public static bool IsPostgreSQL = true;
    }
}
