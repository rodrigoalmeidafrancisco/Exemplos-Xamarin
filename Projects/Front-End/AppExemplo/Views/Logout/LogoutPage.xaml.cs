using AppExemplo.Commun.Helpers;
using ExtensionXamarin;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppExemplo.Views.Logout
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogoutPage : ContentPage
    {
        public LogoutPage()
        {
            InitializeComponent();
            HelperPreferences.ClearSharedName(GlobalApp.Preferences_Shared_Login);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await HelperNavigate.LoginPageAsync(this);
        }
    }
}