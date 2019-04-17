﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class EstaqRepository : IRepository<Estaq>
    {
        private DataBase dataBase;

        public EstaqRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Estaq estaq)
        {
            try
            {
                dataBase._conexao.Insert(estaq);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Estaq> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Estaq entidade)
        {
            throw new NotImplementedException();
        }

        public Estaq ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Estaq> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
