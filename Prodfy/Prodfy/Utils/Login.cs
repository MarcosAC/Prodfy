using Prodfy.Services.Repository;

namespace Prodfy.Utils
{
    public class Login
    {
        public static bool UsuarioEstaLogado()
        {
            UserRepository userRepository = new UserRepository();

            var dadosUser = userRepository.ObterDados();

            if (dadosUser?.sinc_stat == 1)
                return true;

            return false;
        }
    }
}
