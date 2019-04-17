using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ProdutoRepository : IRepository<Produto>
    {
        private DataBase dataBase;

        public ProdutoRepository()
        {
            dataBase = new DataBase();
        }

        public string ObterDados(string id)
        {
            //var ret = "";
            ////var oSTAT = ""
            //var oID = "";
            //var oCODIGO = "";
            //var oOBJETIVO = "";
            //var oCLIENTE = "";
            //var oPRODUTO = "";

            string selectStr = "SELECT " +
                                    "L.lote_id, L.codigo, L.objetivo, L.cliente, P.titulo " +
                               "FROM " +
                                    "Lote L " +
                               "LEFT JOIN " +
                                    "Produto P " +
                               "ON " +
                                    "P.produto_id = L.produto_id " +
                               "WHERE " +
                                    "L.lote_id = " + "'" + id  + "'" +
                               " LIMIT 1";

            //string selectStr = "SELECT * FROM Lote";

            //var dados = dataBase._conexao.Execute(selectStr).ToString();

            var dados = dataBase._conexao.Execute(selectStr).ToString();

            return dados;
        }

        public void Adicionar(Produto produto)
        {
            try
            {
                dataBase._conexao.Insert(produto);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Produto> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Produto entidade)
        {
            throw new NotImplementedException();
        }

        public Produto ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Produto> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
