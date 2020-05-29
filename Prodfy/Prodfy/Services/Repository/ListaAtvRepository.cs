using Prodfy.Helpers;
using Prodfy.Models;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ListaAtvRepository : IRepository<Lista_Atv>
    {
        private DataBase dataBase;

        public ListaAtvRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Lista_Atv lista_Atv)
        {
            try
            {
                dataBase._conexao.Insert(lista_Atv);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }
               
        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Lista_Atv>();
        }

        public List<Lista_Atv> ObterTodos()
        {
            var lista = dataBase._conexao.Table<Lista_Atv>().OrderBy(la => la.idLista_Atv).ToList();
            return lista;
        }
    }
}
