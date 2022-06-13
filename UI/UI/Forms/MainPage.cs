using System.Xml.Schema;

namespace UI.Forms
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using var db = new Services.DatabaseControl("192.168.0.110");
            var temp = db.MainCats.Where(c => c.Id==int.Parse(this.id.Text)).ToList();
        }
    }
}