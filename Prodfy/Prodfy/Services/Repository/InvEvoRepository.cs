using Prodfy.Helpers;
using Prodfy.Models;
using System;

namespace Prodfy.Services.Repository
{
    public class InvEvoRepository : IRepository<Inv_Evo>
    {
        private readonly DataBase _dataBase;

        public InvEvoRepository()
        {
            _dataBase = new DataBase();
        }

        public void Adicionar(Inv_Evo invEvo)
        {
            try
            {
                _dataBase._conexao.Insert(invEvo);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public void DeletarTodos()
        {
            _dataBase._conexao.DeleteAll<Inv_Evo>();
        }
    }
}
