using System;
using System.Collections.Generic;

namespace UI.Services.SQLite
{
    public partial class MainCat
    {
        public MainCat()
        {
            SubCats = new HashSet<SubCat>();
        }

        public long Mid { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }

        public virtual ICollection<SubCat> SubCats { get; set; }
    }
}
