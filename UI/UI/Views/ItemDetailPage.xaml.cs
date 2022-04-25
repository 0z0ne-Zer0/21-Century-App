using System.ComponentModel;
using UI.ViewModels;
using Xamarin.Forms;

namespace UI.Views
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