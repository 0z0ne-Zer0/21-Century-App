using Catalog.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Catalog.Views
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