using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class CatalogItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public bool? Isinstock { get; set; }
        public bool? Isdiscount { get; set; }
        public float? Price { get; set; }
        public float? Oldprice { get; set; }
        public string? Props { get; set; }
        public int? Pid { get; set; }

        public virtual SubCat? PidNavigation { get; set; }
    }
}
