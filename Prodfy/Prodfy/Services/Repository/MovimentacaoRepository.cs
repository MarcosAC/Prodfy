using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    class MovimentacaoRepository : IRepository<Movimentacao>
    {
        private DataBase dataBase;

        public MovimentacaoRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = dataBase._conexao.Table<Movimentacao>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Movimentacao movimentacao)
        {
            try
            {
                dataBase._conexao.Insert(movimentacao);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Movimentacao> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.Execute("Delete From Movimentacao");
        }

        public void Editar(Movimentacao entidade)
        {
            throw new NotImplementedException();
        }

        public Movimentacao ObterDados()
        {
            throw new NotImplementedException();
        }

        public Movimentacao ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterLoteInfo(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Movimentacao> ObterTodos()
        {
            return dataBase._conexao.Table<Movimentacao>().OrderBy(m => m.idMovimentacao).ToList();
        }

        public string ObterMudaInfo(int id)
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
