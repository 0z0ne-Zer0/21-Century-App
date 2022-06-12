using 
21_Century.DataService;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace 21_Century.Views
{
    /// <summary>
    /// Page to show the catalog list. 
    /// </summary>
    [Preserve(AllMembers = true)]
[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class CatalogListPage1
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CatalogListPage1" /> class.
    /// </summary>
    public CatalogListPage1()
    {
        this.InitializeComponent();
        this.BindingContext = CatalogDataService.Instance.CatalogPageViewModel;
    }
}
}