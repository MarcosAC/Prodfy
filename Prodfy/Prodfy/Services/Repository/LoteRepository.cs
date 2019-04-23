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
            
            var query = from lote in listaLotes
                        join produto in listaProdutos on lote.produto_id equals produto.produto_id into gj
                        from produto in gj.DefaultIfEmpty()
                        where lote.codigo == id
                        select new {
                                        lote.lote_id,
                                        lote.codigo,
                                        lote.objetivo,
                                        lote.cliente,
                                        produto.titulo
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

                string ret = string.Empty;

                if (!string.IsNullOrEmpty(loteInfo.lote_id))
                {
                    ret = $"1||{loteInfo.lote_id}|{loteInfo.codigo}|{loteInfo.objetivo}|{loteInfo.cliente}|{loteInfo.produto}|";                    
                }
                else
                {
                    ret = "0|Registro não encontrado!|";
                }

                return ret;
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
