using Prodfy.Services.Repository;

namespace Prodfy.Utils
{
    public static class Login
    {
        public static VerificaLogin VerificaLogin { get; }
    }

    public class VerificaLogin
    {
        private UserRepository userRepository;

        public VerificaLogin()
        {
            userRepository = new UserRepository();
        }

        public bool UsuarioEstaLogado()
        {
            var dadosUser = userRepository.ObterDados();

            if (dadosUser?.senha != null)
                if (dadosUser?.senha == dadosUser?.senha)
                    return true;

            return false;
        }
    }
}
