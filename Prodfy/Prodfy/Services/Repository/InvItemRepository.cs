using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodfy.Services.Repository
{
    public class InvItemRepository : IRepository<Inv_Item>
    {
        DataBase dataBase;

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
            var where = string.Empty;
            var cap = string.Empty;

            var query = "SELECT data_estaq FROM Inv_Item";

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
                where = $" WHERE {where}";

            query += where;
            query += " GROUP BY data_estaq";
            query += " ORDER BY 1";
            
            return dataBase._conexao.Query<Inv_Item>(query);
        }

        public List<Inv_Item> ObterDataSelecao(int loteId, int mudaId, int qualidadeId, string dataEstaqueamento)
        {
            var listaInvItem = dataBase._conexao.Query<Inv_Item>("SELECT * FROM Inv_Item");

            List<Inv_Item> resultado = new List<Inv_Item>();

            var dados =
                from dataSelecao in listaInvItem
                where dataSelecao.data_estaq == Convert.ToDateTime(dataEstaqueamento) || dataSelecao.lote_id == loteId || dataSelecao.muda_id == mudaId || dataSelecao.qualidade_id == qualidadeId
                select dataSelecao;

            foreach (var item in dados)
            {
                resultado.Add(item);
            }

            return resultado;
        }

        public SQLite.TableQuery<Inv_Item> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Inv_Item>();
        }

        public void Editar(Inv_Item entidade)
        {
            throw new NotImplementedException();
        }

        public Inv_Item ObterDados()
        {
            throw new NotImplementedException();
        }

        public Inv_Item ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Inv_Item> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
