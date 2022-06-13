using System.Xml.Schema;

namespace UI.Forms
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void catalog_Click(object sender, EventArgs e)
        {
            var open = new CategorySelect(this);
            open.Show();
            this.Hide();
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
    }
}