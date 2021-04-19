using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExemplo.Views.Functionalities.Plugins.XamPluginMedia
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class XamPluginMediaPage : ContentPage
    {
        private readonly XamPluginMediaPageViewModel _viewModel;

        public XamPluginMediaPage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new XamPluginMediaPageViewModel(this);
        }

    }
}