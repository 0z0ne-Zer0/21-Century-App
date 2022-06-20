using System;
using System.Collections.Generic;

namespace  _21CENT.SQlite
{
    public partial class SubCat
    {
        public SubCat()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public long Sid { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public long? Pages { get; set; }
        public long? Pmid { get; set; }

        public virtual MainCat? Pm { get; set; }
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
