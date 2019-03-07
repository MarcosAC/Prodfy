using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using System.Threading.Tasks;

namespace Prodfy.Utils
{
    public class Login
    {
        //public static VerificaLogin VerificaLogin { get; }
        //private readonly IDialogService dialogService;

        //private UserRepository userRepository;

        //public Login()
        //{
        //    //dialogService = new DialogService();

        //    //userRepository = new UserRepository();
        //}

        public static bool UsuarioEstaLogado(/*string senha = null*/)
        {
            UserRepository userRepository = new UserRepository();

            var dadosUser = userRepository.ObterDados();

            if (dadosUser?.sinc_stat == 1)
                return true;

            return false;

            //if (dadosUser?.sinc_stat == 1)
            //{
            //    if (dadosUser?.senha == senha)                
            //        return true;
            //    else                
            //        await dialogService.AlertAsync("Login", "Senha inválida!", "Ok");                             
            //}
        }
    }
}
