using SQLite;

namespace UI.Models
{
    [Table("MainWebPage")]
    public class MainWebPage
    {
        [PrimaryKey, AutoIncrement]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("link")]
        public string Link { get; set; }
    }

    [Table("SubWebPage")]
    public class SubWebPage
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("pages")]
        public int Pages { get; set; }

        [Column("pid")]
        public int PId { get; set; }
    }

    [Table("Item")]
    public class Item
    {
        [Column("id"), PrimaryKey]
        public int Id { get; set; }

        [Column("name")]
        public string Name { get; set; }

        [Column("link")]
        public string Link { get; set; }

        [Column("stock")]
        public bool IsInStock { get; set; }

        [Column("discount")]
        public bool IsDiscount { get; set; }

        [Column("price")]
        public double Price { get; set; }

        [Column("oldprc")]
        public double OldPrice { get; set; }
    }
}