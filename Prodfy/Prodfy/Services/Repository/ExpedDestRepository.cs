using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class ExpedDestRepository : IRepository<Exped_Dest>
    {
        private readonly DataBase dataBase;

        public ExpedDestRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Exped_Dest exped_Dest)
        {
            try
            {
                dataBase._conexao.Insert(exped_Dest);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Exped_Dest>();
        }
    }
}
