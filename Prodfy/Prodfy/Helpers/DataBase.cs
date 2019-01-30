using Prodfy.Models;
using SQLite;
using Xamarin.Forms;

namespace Prodfy.Helpers
{
    public class DataBase
    {
        public SQLiteConnection _conexao;

        public DataBase()
        {
            var dependencyService = DependencyService.Get<IConexaoBancoDados>();

            string stringConexao = dependencyService.Conexao("ProdfyPlantas.sqlite");

            _conexao = new SQLiteConnection(stringConexao);

            _conexao.CreateTable<Atividade>();
            _conexao.CreateTable<Colaborador>();
            _conexao.CreateTable<Contagem>();
            _conexao.CreateTable<Estagio>();
            _conexao.CreateTable<Estaq>();
            _conexao.CreateTable<Evolucao>();
            _conexao.CreateTable<Exped_Dest>();
            _conexao.CreateTable<Expedicao>();
            _conexao.CreateTable<Historico>();
            _conexao.CreateTable<Lista_Atv>();
            _conexao.CreateTable<Lote>();
            _conexao.CreateTable<Lote_Evolucao>();
            _conexao.CreateTable<Lote_Inventario>();
            _conexao.CreateTable<Monit>();
            _conexao.CreateTable<Monit_Cod_Arv>();
            _conexao.CreateTable<Monit_Med>();
            _conexao.CreateTable<Monit_Ocorr>();
            _conexao.CreateTable<Monit_Parcela>();
            _conexao.CreateTable<Muda>();
            _conexao.CreateTable<Objetivo>();
            _conexao.CreateTable<Perda>();
            _conexao.CreateTable<Perda_Motivo>();
            _conexao.CreateTable<Ponto_Controle>();
            _conexao.CreateTable<Produto>();
            _conexao.CreateTable<Qualidade>();
            _conexao.CreateTable<User>();
        }

        //public void Adicionar(object entidade)
        //{
        //    _conexao.Insert(entidade);
        //}

        //public void Deletar(object entidade)
        //{
        //    _conexao.Delete(entidade);
        //}

        //public void Editar(object entidade)
        //{
        //    _conexao.Update(entidade);
        //}

        //public User ObterPorId(int id)
        //{
        //    return _conexao.Table<User>().FirstOrDefault(u => u.idUser == id);
        //}
    }
}
