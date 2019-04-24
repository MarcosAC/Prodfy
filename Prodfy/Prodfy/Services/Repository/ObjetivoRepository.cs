using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ObjetivoRepository : IRepository<Objetivo>
    {
        private DataBase dataBase;

        public ObjetivoRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Objetivo objetivo)
        {
            try
            {
                dataBase._conexao.Insert(objetivo);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Objetivo> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Objetivo entidade)
        {
            throw new NotImplementedException();
        }

        public Objetivo ObterDados()
        {
            throw new NotImplementedException();
        }

        public Objetivo ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Objetivo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
