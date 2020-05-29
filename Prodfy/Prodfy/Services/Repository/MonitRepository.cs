using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class MonitRepository
    {
        private readonly DataBase dataBase;

        public MonitRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Monit monit)
        {
            try
            {
                dataBase._conexao.Insert(monit);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Monit>();
        }
    }
}
