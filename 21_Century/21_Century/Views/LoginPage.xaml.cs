using _21_Century.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace _21_Century.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}