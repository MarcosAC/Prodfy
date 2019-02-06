using Prodfy.Services.Dialog;
using Xamarin.Essentials;

namespace Prodfy.Utils
{
    public class VerificaConexaoInternet
    {        
        public static bool VerificaConexao()
        {
            var current = Connectivity.NetworkAccess;

            if (current == NetworkAccess.Internet)
            {
                return true;
            }
            else
            {                
                return false;
            }            
        }
    }
}
