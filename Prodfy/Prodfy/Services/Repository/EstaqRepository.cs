using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services.Dialog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Prodfy.Services.Repository
{
    public class EstaqRepository
    {
        private readonly DataBase dataBase;

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

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Estaq>();
        }
    }
}