using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Dialog;
using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodfy.Services.Repository
{
    public class EstaqRepository : IRepository<Estaq>
    {
        private DataBase dataBase;

        private readonly IDialogService dialogService;

        public EstaqRepository()
        {
            dataBase = new DataBase();

            dialogService = new DialogService();
        }

        public void Adicionar(Estaq estaq)
        {
            try
            {
                dataBase._conexao.Insert(estaq);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Estaq> AsQueryable()
        {
            return dataBase._conexao.Table<Estaq>();
        }

        public async Task<List<Estaq>> ListaDadosEstaqueamento(int loteId, int mudaId, DateTime dataEstaq)
        {
            string query = "SELECT " +
                             "lote_id, lote, muda_id, muda, data_estaq, qtde, qualidade_id, qualidade, colab_estaq_id, colab_estaq " +
                           "FROM Estaq " +
                           "WHERE lote_id = " + "'" + loteId + "'" +
                           " AND muda_id = " + "'" + mudaId + "'" +
                           " AND data_estaq = " + "'" + dataEstaq + "'" +
                           " ORDER BY lote, muda, data_estaq";

            try
            {
                return dataBase._conexao.Query<Estaq>(query);
            }
            catch (Exception erro)
            {
                await dialogService.AlertAsync("Erro", erro.ToString(), "Ok");
            }

            return dataBase._conexao.Query<Estaq>(query);            
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Estaq entidade)
        {
            throw new NotImplementedException();
        }

        public Estaq ObterDados()
        {
            throw new NotImplementedException();
        }

        public Estaq ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int codigo)
        {
            throw new NotImplementedException();
        }

        public List<Estaq> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}