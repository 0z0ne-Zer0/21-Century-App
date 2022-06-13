using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace Catalog.Themes
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DarkTheme
    {
        public DarkTheme()
        {
            this.InitializeComponent();
        }
    }
}