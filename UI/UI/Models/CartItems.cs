using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI.Services.PostgreSQL;

namespace UI.Models
{
    internal class CartItems
    {
        public static List<CatalogItem> Cart { get; set; } = new List<CatalogItem>();
    }
}
