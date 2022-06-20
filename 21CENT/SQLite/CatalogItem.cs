using System;
using System.Collections.Generic;

namespace _21CENT.SQlite
{
    public partial class CatalogItem
    {
        public long Cid { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public byte[]? Isinstock { get; set; }
        public byte[]? Isdiscount { get; set; }
        public double? Price { get; set; }
        public double? Oldprice { get; set; }
        public string? Props { get; set; }
        public long? Psid { get; set; }

        public virtual SubCat? Ps { get; set; }
    }
}
