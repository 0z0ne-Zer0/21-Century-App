using System.Xml;
using Post = UI.Services.PostgreSQL;

namespace UI.Forms
{
    public partial class Product : Form
    {
        Form parent { get; }
        Post.CatalogItem product { get; }

        public Product(Form parent, Post.CatalogItem product)
        {
            InitializeComponent();
            this.parent = parent;
            this.product = product;
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
            this.productName.Text = product.Name;
            if ((bool)product.Isdiscount)
            {
                this.Price.Text = product.Price.ToString();
                Price.Font = new(Price.Font, FontStyle.Strikeout);
                this.oldPrice.Text = product.Oldprice.ToString();
            }
            else
            {
                this.Price.Text = product.Price.ToString();
                this.oldPrice.Enabled = false;
            }
            XmlDocument doc = new();
            doc.LoadXml(product.Props);
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
            productImage.Load("https://cdn21vek.by/img/galleries/7360/969/preview_b/32le5051d_horizont_6242ac6959a5b.jpeg");
        }

        private void Product_FormClosing(object sender, FormClosingEventArgs e)=>parent.Show();

        private void addToCart_Click(object sender, EventArgs e)=>Models.CartItems.Cart.Add(product);
    }
}
