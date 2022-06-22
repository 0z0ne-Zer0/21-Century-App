using Post = UI.Services.PostgreSQL;

namespace UI.Forms
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            IP.Text = Post.DatabaseContext.Host;
            DB_Switch();
        }

        private void DB_Switch()
        {
            if (localDB.Checked)
            {
                fileLocation.Enabled = true;
                openLocal.Enabled = true;
                createLocal.Enabled = true;
                remoteSave.Enabled = false;
                IP.Enabled = false;
            }
            else
            {
                fileLocation.Enabled = false;
                openLocal.Enabled = false;
                createLocal.Enabled = false;
                remoteSave.Enabled = true;
                IP.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Post.DatabaseContext.Host = this.IP.Text;
            try
            {
                var tmp = new Post.DatabaseContext().MainCats.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Incorrect IP and/or there is no DB on this IP");
                //MessageBox.Show(ex.Message);
                return;
            }
            this.Close();
        }

        private void DB_CheckedChanged(object sender, EventArgs e)=>DB_Switch();

        private void Cancel_Click(object sender, EventArgs e)=>this.Close();
    }
}