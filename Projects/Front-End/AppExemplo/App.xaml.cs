using AppExemplo.Views.Login;
using Xamarin.Forms;

namespace AppExemplo
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            //DependencyService.Register<MockDataStore>();

            //Defino em qual Page o APP irá iniciar
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
