using _21_Century.Models;
using _21_Century.ViewModels;
using Xamarin.Forms;

namespace _21_Century.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}