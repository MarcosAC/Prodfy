﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
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

        public TableQuery<Lista_Atv> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Lista_Atv entidade)
        {
            throw new NotImplementedException();
        }

        public Lista_Atv ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Lista_Atv> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
