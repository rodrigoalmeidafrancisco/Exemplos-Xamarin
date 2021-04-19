using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExemplo.Views.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly HomePageViewModel _viewModel;

        public HomePage()
        {
            InitializeComponent();
            this.BindingContext = _viewModel = new HomePageViewModel(this);
        }


    }
}