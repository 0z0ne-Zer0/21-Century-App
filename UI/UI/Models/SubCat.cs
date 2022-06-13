using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class SubCat
    {
        public SubCat()
        {
            CatalogItems = new HashSet<CatalogItem>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Link { get; set; }
        public int? Pages { get; set; }
        public int? Pid { get; set; }

        public virtual MainCat? PidNavigation { get; set; }
        public virtual ICollection<CatalogItem> CatalogItems { get; set; }
    }
}