﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ColaboradorRepository : IRepository<Colaborador>
    {
        private DataBase dataBase;

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

        public TableQuery<Colaborador> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Colaborador>();
        }

        public void Editar(Colaborador entidade)
        {
            throw new NotImplementedException();
        }

        public Colaborador ObterDados()
        {
            throw new NotImplementedException();
        }

        public Colaborador ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Colaborador> ObterTodos()
        {
            return dataBase._conexao.Table<Colaborador>().OrderBy(c => c.idColaborador).ToList();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
