using System;
using System.Collections.Generic;

namespace UI.Models
{
    public partial class MainCat
    {
        public MainCat()
        {
            SubCats = new HashSet<SubCat>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }

        public virtual ICollection<SubCat> SubCats { get; set; }
    }
}
