using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class InvRepository
    {
        private readonly DataBase dataBase;

        public InvRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Inv inv)
        {
            try
            {
                dataBase._conexao.Insert(inv);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Inv>();
        }
    }
}
