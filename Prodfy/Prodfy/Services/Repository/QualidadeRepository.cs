﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class QualidadeRepository : IRepository<Qualidade>
    {
        private DataBase dataBase;

        public QualidadeRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Qualidade qualidade)
        {
            try
            {
                dataBase._conexao.Insert(qualidade);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Qualidade> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Qualidade entidade)
        {
            throw new NotImplementedException();
        }

        public Qualidade ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Qualidade> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}