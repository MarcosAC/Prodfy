using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prodfy.Services.Repository
{
    public class LoteRepository : IRepository<Lote>
    {
        private DataBase dataBase;

        public LoteRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = dataBase._conexao.Table<Lote>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public string ObterDados(string id)
        {

            string selectStr = "SELECT " +
                                    "L.lote_id, L.codigo, L.objetivo, L.cliente, P.titulo " +
                               "FROM " +
                                    "Lote L " +
                               "LEFT JOIN " +
                                    "Produto P " +
                               "ON " +
                                    "P.produto_id = L.produto_id " +
                               "WHERE " +
                                    "L.codigo = " + "'" + id + "'" + "";

            //var dados = dataBase._conexao.Query<LoteInfo>(selectStr);

            var dadosLote = dataBase._conexao.Query<Lote>("select * from Lote");
            List<Lote> listaLotes = new List<Lote>();

            foreach (var item in dadosLote)
            {
                listaLotes.Add(item);
            }

            var dadosProduto = dataBase._conexao.Query<Produto>("select * from Produto");
            List<Produto> listaProdutos = new List<Produto>();

            foreach (var item in dadosProduto)
            {
                listaProdutos.Add(item);
            }

            //L.lote_id, L.codigo, L.objetivo, L.cliente, P.titulo
            var query = from L in listaLotes
                        join P in listaProdutos on L.produto_id equals P.produto_id into gj
                        from subInfo in gj.DefaultIfEmpty()
                        where L.codigo == id
                        select new {
                                    L.lote_id,
                                    L.codigo,
                                    L.objetivo,
                                    L.cliente,
                                     subInfo.titulo
                                   };

            

            foreach (var item in query)
            {
                var loteInfo = new 
                {
                    item.lote_id,
                    item.codigo,
                    item.objetivo,
                    item.cliente,
                    produto = item.titulo
                };

                return loteInfo.ToString();
            }

            return null;
        }

        public void ListaLotes()
        {
            var listaLotes = dataBase._conexao.Query<Lote>("Select * From Lote");
        }

        public void Adicionar(Lote lote)
        {
            try
            {
                dataBase._conexao.Insert(lote);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Lote> AsQueryable()
        {
            var dados = dataBase._conexao.Table<Lote>();
            return dados;
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Lote entidade)
        {
            throw new NotImplementedException();
        }

        public Lote ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Lote> ObterTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
