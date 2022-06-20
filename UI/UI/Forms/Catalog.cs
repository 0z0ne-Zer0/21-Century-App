namespace UI.Forms
{
    public partial class Catalog : Form
    {
        private int parrentID;
        private Form parent { get; }
        private Models.SubCat Category { get; set; }

        public Catalog(int parrentID, Form parent)
        {
            InitializeComponent();
            this.parrentID = parrentID;
            this.parent = parent;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var open = new Settings();
            open.Show();
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var open = new Cart(null);
            open.Show();
        }

        private void Catalog_Load(object sender, EventArgs e)
        {
            var db = new Services.PostDatabaseControl();
            Category = db.SubCats.First(c => c.Sid == parrentID);
            var maxPages = Category.Pages;
            pageCounter.Text = $"1/{maxPages}";
            LoadPage();
        }

        private void LoadPage()
        {
            var db = new Services.PostDatabaseControl();
            var catalog = db.CatalogItems.Where(c => c.Psid == parrentID).ToList();
            var curPage = int.Parse(pageCounter.Text.Split('/')[0]);
            for (int i = 0 + ((curPage - 1) * 60); i < 60 * curPage && i < catalog.Count; i++)
            {
                Products.Rows.Add(catalog[i].Name, catalog[i].Isinstock, catalog[i].Isdiscount, catalog[i].Price, catalog[i].Oldprice);
            }
            if (catalog.Count <= curPage * 60)
                backgroundWorker1.RunWorkerAsync(curPage + 1);
        }

        private void Products_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || Products.SelectedRows.Count == 0)
                return;
            DataGridViewRow item = Products.SelectedRows[0];

            if (item != null)
            {
                var db = new Services.PostDatabaseControl();
                //MessageBox.Show("The selected Item Name is: " + item.Cells[1]);
                var T = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                var open = new Product(this, T);
                open.Show();
                this.Hide();
            }
        }

        private void Catalog_FormClosing(object sender, FormClosingEventArgs e) => parent.Show();

        private async void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var db = new Services.PostDatabaseControl();
            var catalog = db.SubCats.First(c => c.Sid == parrentID);
            var nextPage = int.Parse(e.Argument.ToString());
            if (catalog.Pages < nextPage)
                return;
            var tmp = Services.ParserCore.CatalogGet(catalog.Link + $"page:{nextPage}");
            Parallel.ForEach(tmp, T =>
            {
                T.Psid = catalog.Sid;
                var _ = Services.ParserCore.GetProperties(T.Link);
                T.Props = _.Props;
                T.Isinstock = _.Isinstock;
                T.Isdiscount = _.Isdiscount;
                T.Price = _.Price;
                T.Oldprice = _.Oldprice;
            });
            foreach(var T in tmp)
            {
                var res = db.CatalogItems.FirstOrDefault(c => (c.Name == T.Name) && (c.Psid == catalog.Sid));
                if (res != null)
                {
                    res.Props = T.Props;
                    res.Price = T.Price;
                    res.Oldprice = T.Oldprice;
                    res.Isinstock = T.Isinstock;
                    res.Isdiscount = T.Isdiscount;
                    db.Update(res);
                }
                else
                    db.Add(T);
            }
            await db.SaveChangesAsync();
        }

        private void next_Click(object sender, EventArgs e)
        {
            int max = int.Parse(pageCounter.Text.Split('/')[1]), cur = int.Parse(pageCounter.Text.Split('/')[0]);
            pageCounter.Text = $"{cur + 1}/{max}";
            LoadPage();
        }

        private void Products_MouseDoubleClick(object sender, EventArgs e)
        {
            if (Products.SelectedRows.Count == 0)
                return;
            DataGridViewRow item = Products.SelectedRows[0];

            if (item != null)
            {
                var db = new Services.PostDatabaseControl();
                //MessageBox.Show("The selected Item Name is: " + item.Cells[1]);
                var T = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                var open = new Product(this, T);
                open.Show();
                this.Hide();
            }
        }
    }
}