using Post = UI.Services.PostgreSQL;
using Lite = UI.Services.SQLite;

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
            if(UI.Models.SharedResources.IsPostgreSQL)
                foreach(var I in Models.SharedResources.PostCart)
                    Data.Rows.Add(I.Name, I.Isinstock, I.Isdiscount, I.Price, I.Oldprice);
            else
                foreach (var I in Models.SharedResources.LiteCart)
                    Data.Rows.Add(I.Name, I.Isinstock, I.Isdiscount, I.Price, I.Oldprice);
        }

        private void Data_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Data.SelectedRows.Count == 0)
                return;
            DataGridViewRow item = Data.SelectedRows[0];
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (UI.Models.SharedResources.IsPostgreSQL)
                {
                    var db = new Post.DatabaseContext();
                    var open = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                    var T = new Product(RefParent, open);
                    T.Show();
                    this.Close();
                }
                else
                {
                    var db = new Lite.DatabaseContext();
                    var open = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                    var T = new Product(RefParent, open);
                    T.Show();
                    this.Close();
                }
            }
        }

        private void Data_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (Data.SelectedRows.Count == 0)
                return;
            DataGridViewRow item = Data.SelectedRows[0];
            if (UI.Models.SharedResources.IsPostgreSQL)
            {
                var del = Models.SharedResources.PostCart.Find(c => c.Name == item.Cells[0].Value.ToString());
                Models.SharedResources.PostCart.Remove(del);
            }
            else
            {
                var del = Models.SharedResources.LiteCart.Find(c => c.Name == item.Cells[0].Value.ToString());
                Models.SharedResources.LiteCart.Remove(del);
            }
        }
    }
}