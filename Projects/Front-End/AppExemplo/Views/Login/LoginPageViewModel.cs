using AppExemplo.Views.Base;
using AppExemplo.Views.Home;
using ExtensionCore;
using ExtensionXamarin;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppExemplo.Views.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        public LoginPageViewModel()
        {
            //_ = CheckLoginAsync();
            LoginCommand = new Command(async () => { await LoginClickedAsync(); }, 
                () => { return !NameUser.IsNullOrEmptyOrWhiteSpace(); }); //Faz com que o botão seja habilitado apenas quando a variável NOME seja preenchida.
        }

        #region Properties

        public Command LoginCommand { get; }

        private string nameUser;
        public string NameUser 
        { 
            get => nameUser; 
            set 
            { 
                nameUser = value; OnPropertyChanged(); 
                ((Command)LoginCommand).ChangeCanExecute(); //Faz com que o botão seja habilitado apenas quando a variável NOME seja preenchida.
            }
        }  

        #endregion Properties

        #region Methods

        private async Task LoginClickedAsync()
        {
            HelperPreferences.Insert(GlobalApp.Preferences_Key_Login, true, GlobalApp.Preferences_Shared_Login);
            HelperPreferences.Insert(GlobalApp.Preferences_Key_NameUser, this.NameUser, GlobalApp.Preferences_Shared_Login);
            await GoToHomePageAsync();
        }

        public async Task CheckLoginAsync()
        {
            //await Task.Delay(10); //Para dar tempo do APP carregar e poder enviar a HomePage com sucesso, caso já tenha sido feito o login.

            bool login = HelperPreferences.Get(GlobalApp.Preferences_Key_Login, false, GlobalApp.Preferences_Shared_Login);
            string nameUser = HelperPreferences.Get(GlobalApp.Preferences_Key_NameUser, string.Empty, GlobalApp.Preferences_Shared_Login);

            if (login && !nameUser.IsNullOrEmptyOrWhiteSpace())
            {
                await GoToHomePageAsync();
            }
        }

        private async Task GoToHomePageAsync()
        {
            //Inicio o MainPage aqui para que seja possível realizar a navegação no Shell.
            Application.Current.MainPage = new AppShell();

            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}", true);
        }

        #endregion Methods
    }
}
