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

        public void DeletarTodos()
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

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Produto ObterDadosPorId(string id)
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
