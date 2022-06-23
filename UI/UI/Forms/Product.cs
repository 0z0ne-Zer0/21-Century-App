using System.Xml;
using Post = UI.Services.PostgreSQL;
using Lite = UI.Services.SQLite;

namespace UI.Forms
{
    public partial class Product : Form
    {
        Form parent { get; }
        Post.CatalogItem productPost { get; }
        Lite.CatalogItem productLite { get; }


        public Product(Form parent, Post.CatalogItem product)
        {
            InitializeComponent();
            this.parent = parent;
            this.productPost = product;
        }
        public Product(Form parent, Lite.CatalogItem product)
        {
            InitializeComponent();
            this.parent = parent;
            this.productLite = product;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var open = new Settings();
            open.Show();
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var open = new Cart(parent);
            open.Show();
        }

        private void Product_Load(object sender, EventArgs e)
        {
            if (UI.Models.SharedResources.IsPostgreSQL)
            {
                this.productName.Text = productPost.Name;
                if ((bool)productPost.Isdiscount)
                {
                    this.Price.Text = productPost.Price.ToString();
                    Price.Font = new(Price.Font, FontStyle.Strikeout);
                    this.oldPrice.Text = productPost.Oldprice.ToString();
                }
                else
                {
                    this.Price.Text = productPost.Price.ToString();
                    this.oldPrice.Enabled = false;
                }
                XmlDocument doc = new();
                doc.LoadXml(productPost.Props);
                foreach (XmlElement T in doc.DocumentElement.ChildNodes)
                {

                    var name = T.Attributes["name"].Value;
                    itemData.Rows.Add(name, null);
                    var last = itemData.Rows.Count - 1;
                    var q = new Font(Font, FontStyle.Bold);
                    itemData.Rows[last].Cells[0].Style.Font = q;
                    foreach (XmlElement I in T.ChildNodes)
                    {
                        var type = I.Attributes["type"].Value;
                        var value = I.InnerText.ToString();
                        itemData.Rows.Add(type, value);
                    }
                }
            }
            else
            {
                this.productName.Text = productLite.Name;
                if (BitConverter.ToBoolean(productLite.Isdiscount))
                {
                    this.Price.Text = productLite.Price.ToString();
                    Price.Font = new(Price.Font, FontStyle.Strikeout);
                    this.oldPrice.Text = productPost.Oldprice.ToString();
                }
                else
                {
                    this.Price.Text = productLite.Price.ToString();
                    this.oldPrice.Enabled = false;
                }
                XmlDocument doc = new();
                doc.LoadXml(productLite.Props);
                foreach (XmlElement T in doc.DocumentElement.ChildNodes)
                {

                    var name = T.Attributes["name"].Value;
                    itemData.Rows.Add(name, null);
                    var last = itemData.Rows.Count - 1;
                    var q = new Font(Font, FontStyle.Bold);
                    itemData.Rows[last].Cells[0].Style.Font = q;
                    foreach (XmlElement I in T.ChildNodes)
                    {
                        var type = I.Attributes["type"].Value;
                        var value = I.InnerText.ToString();
                        itemData.Rows.Add(type, value);
                    }
                }
            }
            productImage.Load("https://cdn21vek.by/img/galleries/446/413/6560030039_gefest_59008ce4b2d96.jpeg");
        }

        private void Product_FormClosing(object sender, FormClosingEventArgs e)=>parent.Show();

        private void addToCart_Click(object sender, EventArgs e)
        {
            if (UI.Models.SharedResources.IsPostgreSQL)
                Models.SharedResources.PostCart.Add(productPost);
            else
                Models.SharedResources.LiteCart.Add(productLite);
        }
    }
}
