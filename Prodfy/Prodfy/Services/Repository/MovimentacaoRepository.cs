using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    class MovimentacaoRepository : IRepository<Movimentacao>
    {
        private readonly DataBase dataBase;

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

        public void DeletarTodos()
        {
            dataBase._conexao.Execute("Delete From Movimentacao");
        }

        public List<Movimentacao> ObterTodos()
        {
            return dataBase._conexao.Table<Movimentacao>().OrderBy(m => m.idMovimentacao).ToList();
        }
    }
}
