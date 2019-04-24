using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MudaRepository : IRepository<Muda>
    {
        private DataBase dataBase;

        public MudaRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Muda muda)
        {
            try
            {
                dataBase._conexao.Insert(muda);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Muda> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Muda entidade)
        {
            throw new NotImplementedException();
        }

        public Muda ObterDados()
        {
            var dadosMuda = dataBase._conexao.Table<Muda>().FirstOrDefault();
            return dadosMuda;
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Muda> ObterTodos()
        {
            var listaMuda = dataBase._conexao.Table<Muda>().ToList();
            return listaMuda;
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
