using System;
using System.Collections.Generic;

namespace _21CENT.PostgreSQL
{
    public partial class MainCat
    {
        public MainCat()
        {
            SubCats = new HashSet<SubCat>();
        }

        public int Mid { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }

        public virtual ICollection<SubCat> SubCats { get; set; }
    }
}
