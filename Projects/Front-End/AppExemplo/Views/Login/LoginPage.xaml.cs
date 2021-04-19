using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExemplo.Views.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginPageViewModel _viewModel;

        public LoginPage()
        {
            InitializeComponent();

            //Faz com que o valor preechido na tela ou no CS altere o valor da propriedade "LoginPageViewModel.Nome"
            EntryName.SetBinding(Entry.TextProperty, nameof(LoginPageViewModel.NameUser), mode: BindingMode.TwoWay);
            
            this.BindingContext = _viewModel = new LoginPageViewModel(this);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await _viewModel.CheckLoginAsync();
        }
    }
}