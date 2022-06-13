namespace UI.Forms
{
    public partial class CategorySelect : Form
    {
        public Form parent { get; }
        public CategorySelect(Form parrent)
        {
            InitializeComponent();
            this.parent = parrent;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var open = new Settings();
            open.Show();
        }

        private void cartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var open = new Cart();
            open.Show();
        }

        private void Category_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeNode item = Category.SelectedNode;
            if (item != null)
            {
                MessageBox.Show("The selected Item Name is: " + item.Text);
                if (item.Nodes.Count > 0)
                    return;
                var db = new Services.PostDatabaseControl();
                var id = db.SubCats.Where(c => c.Title == item.Text).ToArray()[0].Id;
                var open = new Catalog(id, this);
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
                MessageBox.Show("The selected Item Name is: " + item.Text);
                if (item.Nodes.Count > 0)
                    return;
                var db = new Services.PostDatabaseControl();
                var id = db.SubCats.Where(c => c.Title == item.Text).ToArray()[0].Id;
                var open = new Catalog(id, this);
                open.Show();
                this.Hide();
            }
        }

        private void CategorySelect_Load(object sender, EventArgs e)
        {
            var db = new Services.PostDatabaseControl();
            var temp = db.MainCats.ToList();
            foreach (var item in temp)
            {
                var _ = db.SubCats.Where(c=> c.Pid==item.Id).ToList();
                var children= new List<TreeNode>();
                foreach (var child in _)
                {
                    var tmp = new TreeNode(child.Title);
                    children.Add(tmp);
                }
                var t = new TreeNode(item.Name, children.ToArray());
                this.Category.Nodes.Add(t);
            }
        }

        private void CategorySelect_FormClosing(object sender, FormClosingEventArgs e)=>parent.Show();
    }
}