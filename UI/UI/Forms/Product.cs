using System.Xml;

namespace UI.Forms
{
    public partial class Product : Form
    {
        Form parent { get; }
        Models.CatalogItem product { get; }

        public Product(Form parent, Models.CatalogItem product)
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
            foreach (XmlElement T in doc)
            {
                if (T.Name == "section")
                {
                    var name = T.Attributes["name"];
                    itemData.Rows.Add(name, null);
                    var last = itemData.Rows.Count - 1;
                    itemData.Rows[last].Cells[0].Style.Font = new(itemData.Rows[last].Cells[0].Style.Font, FontStyle.Bold);
                }
                else
                {
                    var type = T.Attributes["type"].ToString();
                    var value = T.InnerText.ToString();
                    itemData.Rows.Add(prop, value);
                }
            }
        }

        private void Product_FormClosing(object sender, FormClosingEventArgs e)=>parent.Show();

        private void addToCart_Click(object sender, EventArgs e)=>Models.CartItems.Cart.Add(product);
        
    }
}
