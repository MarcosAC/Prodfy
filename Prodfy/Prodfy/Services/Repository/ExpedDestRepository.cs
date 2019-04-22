﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ExpedDestRepository : IRepository<Exped_Dest>
    {
        private DataBase dataBase;

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

        public TableQuery<Exped_Dest> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Exped_Dest entidade)
        {
            throw new NotImplementedException();
        }

        public Exped_Dest ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Exped_Dest> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}