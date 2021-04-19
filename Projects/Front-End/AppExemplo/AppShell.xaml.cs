using AppExemplo.Views.Functionalities.Plugins.XamPluginMedia;
using AppExemplo.Views.Home;
using AppExemplo.Views.Logout;
using Xamarin.Forms;

namespace AppExemplo
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            this.BindingContext = this;
        }

        private void RegisterRoutes()
        {
            //Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(LogoutPage), typeof(LogoutPage));

            //Functionalities/Plugins
            Routing.RegisterRoute(nameof(XamPluginMediaPage), typeof(XamPluginMediaPage));

        }
        
    }
}
