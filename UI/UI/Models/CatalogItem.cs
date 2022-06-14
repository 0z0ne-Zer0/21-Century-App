using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class CatalogItem
    {
        public int Cid { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public bool? Isinstock { get; set; }
        public bool? Isdiscount { get; set; }
        public float? Price { get; set; }
        public float? Oldprice { get; set; }
        public string? Props { get; set; }
        public int? Psid { get; set; }

        public virtual SubCat? Ps { get; set; }
    }
}
