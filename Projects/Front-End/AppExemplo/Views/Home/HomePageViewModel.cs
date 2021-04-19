using AppExemplo.Commun.Helpers;
using AppExemplo.Views.Base;
using AppExemplo.Views.Functionalities.Plugins.XamPluginMedia;
using ExtensionXamarin;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppExemplo.Views.Home
{
    public class HomePageViewModel : BaseViewModel
    {
        public HomePageViewModel(Page currentPage) : base(currentPage)
        {
            TxtNameUser = HelperPreferences.Get(GlobalApp.Preferences_Key_NameUser, string.Empty, GlobalApp.Preferences_Shared_Login);
            XamPluginMediaCommand = new Command(async () => { await HelperNavigate.BaseShell(nameof(XamPluginMediaPage)); });
        }

        #region Properties

        private string txtNameUser;
        public string TxtNameUser { get { return txtNameUser; } set { txtNameUser = value; OnPropertyChanged(); } }

        public ICommand XamPluginMediaCommand { get; private set; }


        #endregion Properties

    }
}
