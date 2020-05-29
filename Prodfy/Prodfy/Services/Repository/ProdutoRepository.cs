using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class ProdutoRepository
    {
        private readonly DataBase dataBase;

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

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Produto>();
        }
    }
}
