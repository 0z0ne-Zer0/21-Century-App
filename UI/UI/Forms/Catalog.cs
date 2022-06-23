using UI.Services.SQLite;
using Post = UI.Services.PostgreSQL;
using Lite = UI.Services.SQLite;

namespace UI.Forms
{
    public partial class Catalog : Form
    {
        private int parrentID { get; set; }
        private Form parent { get; }
        private Post.SubCat CategoryPost { get; set; }
        private List<Post.CatalogItem> searchListPost { get; set; } = null;
        private Lite.SubCat CategoryLite { get; set; }
        private List<Lite.CatalogItem> searchListLite { get; set; } = null;
        int currentPage { get; set; } = 1;
        static readonly Object lockCondition = new();

        public Catalog(int parrentID, Form parent, List<Post.CatalogItem> SL = null, Post.SubCat Cat = null)
        {
            InitializeComponent();
            this.parrentID = parrentID;
            this.parent = parent;
            searchListPost = SL;
            CategoryPost = Cat;
        }

        public Catalog(long id, Form parent, List<Lite.CatalogItem> SL = null, Lite.SubCat Cat = null)
        {
            InitializeComponent();
            this.parrentID = Convert.ToInt32(id);
            this.parent = parent;
            searchListLite = SL;
            CategoryLite = Cat;
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
            if (UI.Models.SharedResources.IsPostgreSQL)
            {
                var db = new Post.DatabaseContext();
                if (parrentID != -1)
                    CategoryPost = db.SubCats.First(c => c.Sid == parrentID);
                pageCounter.Text = $"Страница {currentPage}/{CategoryPost.Pages}";
            }
            else
            {
                var db = new Lite.DatabaseContext();
                if (parrentID != -1)
                    CategoryLite = db.SubCats.First(c => c.Sid == parrentID);
                pageCounter.Text = $"Страница {currentPage}/{CategoryLite.Pages}";
            }
            LoadPage();
        }

        private void LoadPage()
        {
            this.Products.Rows.Clear();
            if (UI.Models.SharedResources.IsPostgreSQL)
            {
                var db = new Post.DatabaseContext();
                List<Post.CatalogItem> catalog = new();
                if (parrentID != -1)
                    catalog = db.CatalogItems.Where(c => c.Psid == parrentID).ToList();
                else
                    catalog = searchListPost;
                for (int i = 0 + (currentPage - 1) * 60; i < 60 * currentPage && i < catalog.Count; i++)
                    Products.Rows.Add(catalog[i].Name, catalog[i].Isinstock, catalog[i].Isdiscount, catalog[i].Price, catalog[i].Oldprice);
                if (catalog.Count <= currentPage * 60)
                {
                    switch (true)
                    {
                        case true when !backgroundWorker1.IsBusy:
                            backgroundWorker1.RunWorkerAsync(currentPage + 1);
                            break;
                        case true when !backgroundWorker2.IsBusy:
                            backgroundWorker2.RunWorkerAsync(currentPage + 1);
                            break;
                        case true when !backgroundWorker3.IsBusy:
                            backgroundWorker3.RunWorkerAsync(currentPage + 1);
                            break;
                        case true when !backgroundWorker4.IsBusy:
                            backgroundWorker4.RunWorkerAsync(currentPage + 1);
                            break;
                    }
                }
            }
            else
            {
                var db = new Lite.DatabaseContext();
                List<Lite.CatalogItem> catalog = new();
                if (parrentID != -1)
                    catalog = db.CatalogItems.Where(c => c.Psid == parrentID).ToList();
                else
                    catalog = searchListLite;
                for (int i = 0 + (currentPage - 1) * 60; i < 60 * currentPage && i < catalog.Count; i++)
                    Products.Rows.Add(catalog[i].Name, BitConverter.ToBoolean(catalog[i].Isinstock), BitConverter.ToBoolean(catalog[i].Isdiscount), catalog[i].Price, catalog[i].Oldprice);
                if (catalog.Count <= currentPage * 60)
                {
                    switch (true)
                    {
                        case true when !backgroundWorker5.IsBusy:
                            backgroundWorker5.RunWorkerAsync(currentPage + 1);
                            break;
                        case true when !backgroundWorker6.IsBusy:
                            backgroundWorker6.RunWorkerAsync(currentPage + 1);
                            break;
                        case true when !backgroundWorker7.IsBusy:
                            backgroundWorker7.RunWorkerAsync(currentPage + 1);
                            break;
                        case true when !backgroundWorker8.IsBusy:
                            backgroundWorker8.RunWorkerAsync(currentPage + 1);
                            break;
                    }
                }
            }
        }

        private void Products_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || Products.SelectedRows.Count == 0)
                return;
            DataGridViewRow item = Products.SelectedRows[0];

            if (item != null)
            {
                var open = new Form();
                if (UI.Models.SharedResources.IsPostgreSQL)
                {
                    var db = new Post.DatabaseContext();
                    //MessageBox.Show("The selected Item Name is: " + item.Cells[1]);
                    var T = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                    open = new Product(this, T);
                }
                else
                {
                    var db = new Lite.DatabaseContext();
                    //MessageBox.Show("The selected Item Name is: " + item.Cells[1]);
                    var T = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                    open = new Product(this, T);
                }
                open.Show();
                this.Hide();
            }
        }

        private void Catalog_FormClosing(object sender, FormClosingEventArgs e) => parent.Show();

        private void next_Click(object sender, EventArgs e)
        {
            currentPage++;
            if (!prev.Enabled)
                prev.Enabled = true;

            if (UI.Models.SharedResources.IsPostgreSQL)
            {
                if (currentPage + 1 > CategoryPost.Pages)
                    next.Enabled = false;
                pageCounter.Text = $"Cтраница {currentPage}/{CategoryPost.Pages}";
            }
            else
            { 
                if (currentPage + 1 > CategoryLite.Pages)
                    next.Enabled = false;
                pageCounter.Text = $"Cтраница {currentPage}/{CategoryLite.Pages}";
            }
            
            LoadPage();
        }

        private void Products_MouseDoubleClick(object sender, EventArgs e)
        {
            if (Products.SelectedRows.Count == 0)
                return;
            DataGridViewRow item = Products.SelectedRows[0];

            if (item != null)
            {
                var open = new Form();
                if (UI.Models.SharedResources.IsPostgreSQL)
                {
                    var db = new Post.DatabaseContext();
                    //MessageBox.Show("The selected Item Name is: " + item.Cells[1]);
                    var T = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                    open = new Product(this, T);
                }
                else
                {
                    var db = new Lite.DatabaseContext();
                    //MessageBox.Show("The selected Item Name is: " + item.Cells[1]);
                    var T = db.CatalogItems.First(c => c.Name == item.Cells[0].Value);
                    open = new Product(this, T);
                }
                open.Show();
                this.Hide();
            }
        }

        private void prev_Click(object sender, EventArgs e)
        {
            currentPage--;
            if (!next.Enabled)
                next.Enabled = true;
            if (currentPage - 1 == 0)
                prev.Enabled = false;
            if (UI.Models.SharedResources.IsPostgreSQL)
                pageCounter.Text = $"Cтраница {currentPage}/{CategoryPost.Pages}";
            else
                pageCounter.Text = $"Cтраница {currentPage}/{CategoryLite.Pages}";
            LoadPage();
        }

        private void backgroundWorkerPost_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (currentPage + 1 > CategoryPost.Pages)
                return;
            var db = new Post.DatabaseContext();
            List<Post.CatalogItem> tmp = new();
            if (parrentID != -1)
            {
                tmp = Services.ParserCorePost.CatalogGet(CategoryPost.Link + $"page:{currentPage + 1}");
            }
            else
                tmp = Services.ParserCorePost.CatalogGet($"https://www.21vek.by/search/page:{currentPage + 1}/?sa=&term=" + CategoryPost.Title);
            Parallel.ForEach(tmp, T =>
            {
                if (parrentID !=-1)
                    T.Psid = CategoryPost.Sid;
                var _ = Services.ParserCorePost.GetProperties(T.Link);
                T.Props = _.Props;
                T.Isinstock = _.Isinstock;
                T.Isdiscount = _.Isdiscount;
                T.Price = _.Price;
                T.Oldprice = _.Oldprice;
            });

            if (parrentID != -1)
                lock (lockCondition)
                {
                    try
                    {
                        foreach (var T in tmp)
                        {
                            var res = db.CatalogItems.FirstOrDefault(c => (c.Name == T.Name) && (c.Link == c.Link));
                            if (res != null)
                            {
                                res.Props = T.Props;
                                res.Price = T.Price;
                                res.Oldprice = T.Oldprice;
                                res.Isinstock = T.Isinstock;
                                res.Isdiscount = T.Isdiscount;
                            }
                            else
                                db.Add(T);
                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            else
                foreach (var T in tmp)
                {
                    var res = searchListPost.FirstOrDefault(c => (c.Name == T.Name) && (c.Link == c.Link));
                    if (res != null)
                    {
                        res.Props = T.Props;
                        res.Price = T.Price;
                        res.Oldprice = T.Oldprice;
                        res.Isinstock = T.Isinstock;
                        res.Isdiscount = T.Isdiscount;
                    }
                    else
                        searchListPost.Add(T);
                }
        }

        private void backgroundWorkerLite_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (currentPage + 1 > CategoryLite.Pages)
                return;
            var db = new Lite.DatabaseContext();
            List<Lite.CatalogItem> tmp = new();
            if (parrentID != -1)
            {
                tmp = Services.ParserCoreLite.CatalogGet(CategoryLite.Link + $"page:{currentPage + 1}");
            }
            else
                tmp = Services.ParserCoreLite.CatalogGet($"https://www.21vek.by/search/page:{currentPage + 1}/?sa=&term=" + CategoryLite.Title);
            Parallel.ForEach(tmp, T =>
            {
                if (parrentID != -1)
                    T.Psid = CategoryLite.Sid;
                var _ = Services.ParserCoreLite.GetProperties(T.Link);
                T.Props = _.Props;
                T.Isinstock = _.Isinstock;
                T.Isdiscount = _.Isdiscount;
                T.Price = _.Price;
                T.Oldprice = _.Oldprice;
            });

            if (parrentID != -1)
                lock (lockCondition)
                {
                    try
                    {
                        foreach (var T in tmp)
                        {
                            var res = db.CatalogItems.FirstOrDefault(c => (c.Name == T.Name) && (c.Link == c.Link));
                            if (res != null)
                            {
                                res.Props = T.Props;
                                res.Price = T.Price;
                                res.Oldprice = T.Oldprice;
                                res.Isinstock = T.Isinstock;
                                res.Isdiscount = T.Isdiscount;
                            }
                            else
                                db.Add(T);
                        }
                        db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            else
                foreach (var T in tmp)
                {
                    var res = searchListLite.FirstOrDefault(c => (c.Name == T.Name) && (c.Link == c.Link));
                    if (res != null)
                    {
                        res.Props = T.Props;
                        res.Price = T.Price;
                        res.Oldprice = T.Oldprice;
                        res.Isinstock = T.Isinstock;
                        res.Isdiscount = T.Isdiscount;
                    }
                    else
                        searchListLite.Add(T);
                }
        }
    }
}