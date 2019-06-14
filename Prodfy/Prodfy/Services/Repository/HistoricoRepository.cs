using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class HistoricoRepository : IRepository<Historico>
    {
        private DataBase dataBase;

        public HistoricoRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = dataBase._conexao.Table<Historico>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Historico historico)
        {
            try
            {
                dataBase._conexao.Insert(historico);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
           
        }

        public void Deletar(int id)
        {
            dataBase._conexao.Delete<Historico>(id);
        }

        public List<ListaHistorico> ListaDeHistoricos()
        {
            var listaDadosHistoricos = dataBase._conexao.Query<ListaHistorico>("SELECT AA.idhistorico, AA.disp_id, L.lote_id, L.codigo, AA.data, AA.titulo FROM Historico AA INNER JOIN Lote L ON L.lote_id = AA.lote_id ORDER BY AA.data desc");
            return listaDadosHistoricos;
        }

        public TableQuery<Historico> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Historico>();
        }

        public void Editar(Historico entidade)
        {
            throw new NotImplementedException();
        }

        public Historico ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Historico> ObterTodos()
        {
            return dataBase._conexao.Table<Historico>().OrderBy(h => h.idHistorico).ToList();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Historico ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
