using AppExemplo.Views.Base;
using AppExemplo.Views.Home;
using Xamarin.Forms;

namespace AppExemplo.Views.Login
{
    public class LoginPageViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }

        public LoginPageViewModel()
        {
            
            LoginCommand = new Command(OnLoginClicked);
        }

        private async void OnLoginClicked(object obj)
        {
            //Inicio o MainPage aqui para que seja possível realizar a navegação no Shell.
            Application.Current.MainPage = new AppShell();

            ShellNavigationState state = Shell.Current.CurrentState;
            await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
        }
    }
}
