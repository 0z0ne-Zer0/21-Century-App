using Post = UI.Services.PostgreSQL;
using Lite = UI.Services.SQLite;

namespace UI.Forms
{
    public partial class CategorySelect : Form
    {
        Form parent { get; }
        struct SearchContainerPost
        {
            public Post.SubCat subCat { get; }
            public List<Post.CatalogItem> catalogItems { get; }
            public SearchContainerPost(Post.SubCat T, List<Post.CatalogItem> V)
            {
                subCat = T;
                catalogItems = V;
            }
        }
        struct SearchContainerLite
        {
            public Lite.SubCat subCat { get; }
            public List<Lite.CatalogItem> catalogItems { get; }
            public SearchContainerLite(Lite.SubCat T, List<Lite.CatalogItem> V)
            {
                subCat = T;
                catalogItems = V;
            }
        }

        static SearchContainerPost searchContainerPost { get; set; }
        static SearchContainerLite searchContainerLite { get; set; }
        public CategorySelect(Form parent)
        {
            InitializeComponent();
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

        private void Category_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode item = Category.SelectedNode;
            if (item != null)
            {
                //MessageBox.Show("The selected Item Name is: " + item.Text);
                if (item.Nodes.Count > 0)
                    return;
                Form open = new Form();
                if (Models.SharedResources.IsPostgreSQL)
                {
                    var db = new Post.DatabaseContext();
                    var id = db.SubCats.Where(c => c.Title == item.Text).ToArray()[0].Sid;
                    open = new Catalog(parrentID:id, this);
                }
                else
                {
                    var db = new Lite.DatabaseContext();
                    var id = db.SubCats.Where(c => c.Title == item.Text).ToArray()[0].Sid;
                    open = new Catalog(id:id, this);
                }
                open.Show();
                this.Hide();
            }
        }

        private void Category_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || Category.SelectedNode == null)
                return;

            TreeNode item = Category.SelectedNode;
            if (item != null)
            {
                //MessageBox.Show("The selected Item Name is: " + item.Text);
                if (item.Nodes.Count > 0)
                    return;
                Form open = new Form();
                if (Models.SharedResources.IsPostgreSQL)
                {
                    var db = new Post.DatabaseContext();
                    var id = db.SubCats.Where(c => c.Title == item.Text).ToArray()[0].Sid;
                    open = new Catalog(parrentID:id, this);
                }
                else
                {
                    var db = new Lite.DatabaseContext();
                    var id = db.SubCats.Where(c => c.Title == item.Text).ToArray()[0].Sid;
                    open = new Catalog(id:id, this);
                }
                open.Show();
                this.Hide();
            }
        }

        private void CategorySelect_Load(object sender, EventArgs e)
        {
            if (UI.Models.SharedResources.IsPostgreSQL)
            {
                var db = new Post.DatabaseContext();
                var temp = db.MainCats.ToList();
                foreach (var item in temp)
                {
                    var _ = db.SubCats.Where(c => c.Pmid == item.Mid).ToList();
                    var children = new List<TreeNode>();
                    foreach (var child in _)
                    {
                        var tmp = new TreeNode(child.Title);
                        children.Add(tmp);
                    }
                    var t = new TreeNode(item.Name, children.ToArray());
                    this.Category.Nodes.Add(t);
                }
            }
            else
            {
                var db = new Lite.DatabaseContext();
                var temp = db.MainCats.ToList();
                foreach (var item in temp)
                {
                    var _ = db.SubCats.Where(c => c.Pmid == item.Mid).ToList();
                    var children = new List<TreeNode>();
                    foreach (var child in _)
                    {
                        var tmp = new TreeNode(child.Title);
                        children.Add(tmp);
                    }
                    var t = new TreeNode(item.Name, children.ToArray());
                    this.Category.Nodes.Add(t);
                }
            }
        }

        private void CategorySelect_FormClosing(object sender, FormClosingEventArgs e)=>parent.Show();

        private void Search_Click(object sender, EventArgs e)
        {
            var search = searchQuery.Text;
            if (string.IsNullOrEmpty(search))
            {
                MessageBox.Show("Нету строки для поиска");
                return;
            }
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            int progress = 0;
            var search = searchQuery.Text;
            if (UI.Models.SharedResources.IsPostgreSQL)
            {
                Post.SubCat searchQUE = new Post.SubCat { Link = "https://www.21vek.by/search/?sa=&term=" + search, Title = search, Sid = -1 };
                searchQUE.Pages = Services.ParserCorePost.PageCountGet(searchQUE);
                var send = Services.ParserCorePost.CatalogGet(searchQUE.Link);
                Parallel.ForEach(send, T =>
                {
                    T.Psid = searchQUE.Sid;
                    var _ = Services.ParserCorePost.GetProperties(T.Link);
                    T.Props = _.Props;
                    T.Isinstock = _.Isinstock;
                    T.Isdiscount = _.Isdiscount;
                    T.Price = _.Price;
                    T.Oldprice = _.Oldprice;
                    progress += int.Parse(Math.Ceiling(100 / (double)send.Count).ToString());
                    if (progress >= 100)
                        progress = 100;
                    backgroundWorker1.ReportProgress(progress);
                });
                searchContainerPost = new SearchContainerPost(searchQUE, send);
            }
            else
            {
                Lite.SubCat searchQUE = new Lite.SubCat { Link = "https://www.21vek.by/search/?sa=&term=" + search, Title = search, Sid = -1 };
                searchQUE.Pages = Services.ParserCoreLite.PageCountGet(searchQUE);
                var send = Services.ParserCoreLite.CatalogGet(searchQUE.Link);
                Parallel.ForEach(send, T =>
                {
                    T.Psid = searchQUE.Sid;
                    var _ = Services.ParserCoreLite.GetProperties(T.Link);
                    T.Props = _.Props;
                    T.Isinstock = _.Isinstock;
                    T.Isdiscount = _.Isdiscount;
                    T.Price = _.Price;
                    T.Oldprice = _.Oldprice;
                    progress += int.Parse(Math.Ceiling(100 / (double)send.Count).ToString());
                    if (progress >= 100)
                        progress = 100;
                    backgroundWorker1.ReportProgress(progress);
                });
                searchContainerLite = new SearchContainerLite(searchQUE, send);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            searchProgress.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            searchProgress.Value = 0;
            Form open = new Form();
            if (Models.SharedResources.IsPostgreSQL)
                open = new Catalog(-1, this, searchContainerPost.catalogItems, searchContainerPost.subCat);
            else
                open = new Catalog(-1, this, searchContainerLite.catalogItems, searchContainerLite.subCat);
            open.Show();
            this.Hide();
        }
    }
}