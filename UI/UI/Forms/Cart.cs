using Post = UI.Services.PostgreSQL;

namespace UI.Forms
{
    public partial class Cart : Form
    {
        Form RefParent { get; }
        public Cart(Form form)
        {
            InitializeComponent();
            RefParent = form;
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            foreach(var I in Models.CartItems.Cart)
                Data.Rows.Add(I.Name, I.Isinstock, I.Isdiscount, I.Price, I.Oldprice);
        }

        private void Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Data.SelectedRows.Count == 0)
                return;
            DataGridViewRow item = Data.SelectedRows[0];
            if (e.KeyChar == (char)Keys.Delete)
            {
                var del = Models.CartItems.Cart.Find(c => c.Name == item.Cells[0].Value.ToString());
                Models.CartItems.Cart.Remove(del);
                Data.Rows.Remove(item);
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                var db = new Post.DatabaseContext();
                var open = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                var T = new Product(RefParent, open);
            }
        }
    }
}