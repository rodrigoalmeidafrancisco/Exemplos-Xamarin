namespace AppExemplo
{
    public class SettingsApp
    {

#if DEBUG

        public static string UrlApi = "https://localhost:5001/";
        public static bool NotValidateCertificate = true;

#else

        public static string UrlApi = "__UrlApi__";
        public static bool NotValidateCertificate = __NotValidateCertificate__;

#endif

    }
}
