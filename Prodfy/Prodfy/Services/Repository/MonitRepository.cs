using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MonitRepository : IRepository<Monit>
    {
        private DataBase dataBase;

        public MonitRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Monit monit)
        {
            try
            {
                dataBase._conexao.Insert(monit);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Monit> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Monit entidade)
        {
            throw new NotImplementedException();
        }

        public Monit ObterDados()
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Monit> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
