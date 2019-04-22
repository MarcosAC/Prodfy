﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class PerdaMotivoRepository : IRepository<Perda_Motivo>
    {
        private DataBase dataBase;

        public PerdaMotivoRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Perda_Motivo perda_Motivo)
        {
            try
            {
                dataBase._conexao.Insert(perda_Motivo);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Perda_Motivo> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Perda_Motivo entidade)
        {
            throw new NotImplementedException();
        }

        public Perda_Motivo ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Perda_Motivo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}