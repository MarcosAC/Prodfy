using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class ObjetivoRepository : IRepository<Objetivo>
    {
        private readonly DataBase dataBase;

        public ObjetivoRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                dataBase._conexao.Insert(objetivo);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Objetivo>();
        }
    }
}
