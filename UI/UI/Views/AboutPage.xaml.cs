using Xamarin.Forms;
using Xamarin.Essentials;

namespace UI.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var ip = IP.Text;
            SecureStorage.SetAsync("IPAdr", ip);
        }
    }
}