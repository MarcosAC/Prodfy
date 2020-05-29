using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class MonitParcelaRepository
    {
        private readonly DataBase dataBase;

        public MonitParcelaRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Monit_Parcela monit_Parcela)
        {
            try
            {
                dataBase._conexao.Insert(monit_Parcela);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
                
        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Monit_Parcela>();
        } 
    }
}
