using AppExemplo.Views.Home;
using AppExemplo.Views.Login;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppExemplo.Commun.Helpers
{
    public static class HelperNavigate
    {
        /// <summary>
        /// Realiza a navegação para a página destino.
        /// </summary>
        /// <param name="paginaDestino">Informar o nome da página ex.: nameof(HomePage)</param>
        /// <returns></returns>
        public static async Task BaseShell(string paginaDestino)
        {
            try
            {
                ShellNavigationState state = Shell.Current.CurrentState;

                if (paginaDestino.Equals(nameof(HomePage)))
                {
                    await Shell.Current.GoToAsync($"//{paginaDestino}", true);
                }
                else
                {
                    await Shell.Current.GoToAsync($"{state.Location}/{paginaDestino}", true);
                }

                Shell.Current.FlyoutIsPresented = false;
            }
            catch (Exception ex)
            {
                //HelperAppCenter.LogException(ex);
            }
        }

        public static async Task LoginPageAsync(Page page)
        {
            try
            {
                await page.Navigation.PushAsync(new LoginPage(), true);
            }
            catch (Exception ex)
            {
                //HelperAppCenter.LogException(ex);
            }
        }




    }
}
