using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ColaboradorRepository
    {
        private readonly DataBase dataBase;

        public ColaboradorRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Colaborador colaborador)
        {
            try
            {
                dataBase._conexao.Insert(colaborador);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }        

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Colaborador>();
        }

        public List<Colaborador> ObterTodosColaboradores()
        {
            return dataBase._conexao.Table<Colaborador>().OrderBy(c => c.idColaborador).ToList();
        }
    }
}
