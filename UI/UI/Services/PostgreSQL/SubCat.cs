﻿using System;
using System.Collections.Generic;

namespace UI.Services.PostgreSQL
{
    public partial class SubCat
    {
        public SubCat()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public int Sid { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public int? Pages { get; set; }
        public int? Pmid { get; set; }

        public virtual MainCat? Pm { get; set; }
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}
