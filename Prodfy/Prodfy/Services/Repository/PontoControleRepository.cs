using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class PontoControleRepository : IRepository<Ponto_Controle>
    {
        private DataBase dataBase;

        public PontoControleRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Ponto_Controle ponto_Controle)
        {
            try
            {
                dataBase._conexao.Insert(ponto_Controle);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Ponto_Controle> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Ponto_Controle entidade)
        {
            throw new NotImplementedException();
        }

        public Ponto_Controle ObterDados()
        {
            throw new NotImplementedException();
        }

        public Ponto_Controle ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Ponto_Controle> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
