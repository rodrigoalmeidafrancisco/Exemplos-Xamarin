using System;
using System.Net.Http;

namespace AppExemplo.Data.Repositories.Base
{
    public class BaseRepositoryAPI
    {
        protected static HttpClient _client;

        public BaseRepositoryAPI()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();

            if (SettingsApp.NotValidateCertificate)
            {
                clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            }

            _client = new HttpClient(clientHandler)
            {
                BaseAddress = new Uri(SettingsApp.UrlApi)
            };
        }


    }
}
