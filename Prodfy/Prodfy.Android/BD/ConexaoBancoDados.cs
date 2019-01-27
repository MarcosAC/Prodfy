using Prodfy.Droid.BD;
using Prodfy.Helpers;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(ConexaoBancoDados))]
namespace Prodfy.Droid.BD
{
    public class ConexaoBancoDados : IConexaoBancoDados
    {
        public string Conexao(string nomeArquivoBD)
        {
            string stringConexao = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string bancoDados = Path.Combine(stringConexao, nomeArquivoBD);
            return bancoDados;
        }
    }
}