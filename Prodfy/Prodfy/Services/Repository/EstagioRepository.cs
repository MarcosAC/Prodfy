using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class EstagioRepository : IRepository<Estagio>
    {
        private DataBase dataBase;

        public EstagioRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Estagio estagio)
        {
            try
            {
                dataBase._conexao.Insert(estagio);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Estagio> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Estagio entidade)
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDados()
        {
            throw new NotImplementedException();
        }

        public Estagio ObterDadosPorId(string id)
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

        public List<Estagio> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
