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

            CriarTabelas();
        }

        private void CriarTabelas()
        {
            _conexao.CreateTable<Atividade>();
            _conexao.CreateTable<Colaborador>();
            _conexao.CreateTable<Estagio>();
            _conexao.CreateTable<Estaq>();
            _conexao.CreateTable<Exped_Dest>();
            _conexao.CreateTable<Expedicao>();
            _conexao.CreateTable<Expedido>();
            _conexao.CreateTable<Historico>();
            _conexao.CreateTable<Inv>();
            _conexao.CreateTable<Inv_Evo>();
            _conexao.CreateTable<Inv_Item>();
            _conexao.CreateTable<Inventario>();
            _conexao.CreateTable<Lista_Atv>();
            _conexao.CreateTable<Lote>();
            _conexao.CreateTable<Monit>();
            _conexao.CreateTable<Monit_Cod_Arv>();
            _conexao.CreateTable<Monit_Med>();
            _conexao.CreateTable<Monit_Ocorr>();
            _conexao.CreateTable<Monit_Parcela>();
            _conexao.CreateTable<Movimentacao>();
            _conexao.CreateTable<Muda>();
            _conexao.CreateTable<Objetivo>();
            _conexao.CreateTable<Perda>();
            _conexao.CreateTable<Perda_Motivo>();
            _conexao.CreateTable<Ponto_Controle>();
            _conexao.CreateTable<Produto>();
            _conexao.CreateTable<Qualidade>();
            _conexao.CreateTable<User>();
        }

        public void DeletaTodasTabelas()
        {
            _conexao.DeleteAll<Atividade>();
            _conexao.DeleteAll<Colaborador>();
            _conexao.DeleteAll<Estagio>();
            _conexao.DeleteAll<Estaq>();
            _conexao.DeleteAll<Exped_Dest>();
            _conexao.DeleteAll<Expedicao>();
            _conexao.DeleteAll<Expedido>();
            _conexao.DeleteAll<Historico>();
            _conexao.DeleteAll<Inv>();
            _conexao.DeleteAll<Inv_Evo>();
            _conexao.DeleteAll<Inv_Item>();
            _conexao.DeleteAll<Inventario>();
            _conexao.DeleteAll<Lista_Atv>();
            _conexao.DeleteAll<Lote>();
            _conexao.DeleteAll<Monit>();
            _conexao.DeleteAll<Monit_Cod_Arv>();
            _conexao.DeleteAll<Monit_Med>();
            _conexao.DeleteAll<Monit_Ocorr>();
            _conexao.DeleteAll<Monit_Parcela>();
            _conexao.DeleteAll<Movimentacao>();
            _conexao.DeleteAll<Muda>();
            _conexao.DeleteAll<Objetivo>();
            _conexao.DeleteAll<Perda>();
            _conexao.DeleteAll<Perda_Motivo>();
            _conexao.DeleteAll<Ponto_Controle>();
            _conexao.DeleteAll<Produto>();
            _conexao.DeleteAll<Qualidade>();
            _conexao.DeleteAll<User>();
        }
    }
}
