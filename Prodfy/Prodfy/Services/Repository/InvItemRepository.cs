using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InvItemRepository
    {
        private readonly DataBase dataBase;

        public InvItemRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Inv_Item inv_item)
        {
            try
            {
                dataBase._conexao.Insert(inv_item);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }       

        public List<Inv_Item> ObterDataEstaquemento(int loteId, int mudaId, int qualidadeId)
        {
            string query = "SELECT AA.data_estaq FROM Inv_Item AA ";

            string where = string.Empty;
            string cap = string.Empty;

            if (loteId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.lote_id = {loteId}";
            }

            if (mudaId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.muda_id = {mudaId}";
            }

            if (qualidadeId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}AA.qualidade_id = {qualidadeId}";
            }

            if (!string.IsNullOrEmpty(where))
                where = $"WHERE {where}";

            query += $"{where} GROUP BY AA.data_estaq ORDER BY 1";

            var listaDatasEstaquementos = dataBase._conexao.Query<Inv_Item>(query);

            return listaDatasEstaquementos;
        }

        public List<Inv_Item> ObterDataSelecao(int loteId, int mudaId, int qualidadeId, string dataEstaqueamento)
        {
            string query = "SELECT distinct data_selecao FROM Inv_Item ";

            string where = string.Empty;
            string cap = string.Empty;

            //where += $"date(data_estaq) = {dataEstaqueamento}";

            if (loteId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}lote_id = {loteId}";
            }

            if (mudaId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}muda_id = {mudaId}";
            }

            if (qualidadeId > 0)
            {
                if (!string.IsNullOrEmpty(where))
                    cap = " AND ";

                where += $"{cap}qualidade_id = {qualidadeId}";
            }

            if (!string.IsNullOrEmpty(where))
                where = $"WHERE {where}";

            query += $"{where} ORDER BY data_selecao desc";

            var listaDatasSelecao = dataBase._conexao.Query<Inv_Item>(query);

            return listaDatasSelecao;
        }
                
        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Inv_Item>();
        }
    }
}
