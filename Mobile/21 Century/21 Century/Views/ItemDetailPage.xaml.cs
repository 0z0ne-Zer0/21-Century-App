using _21_Century.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace _21_Century.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}