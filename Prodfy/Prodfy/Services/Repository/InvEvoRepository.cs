using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InvEvoRepository : IRepository<Inv_Evo>
    {
        DataBase dataBase;

        public InvEvoRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Inv_Evo invEvo)
        {
            try
            {
                dataBase._conexao.Insert(invEvo);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "Ok");
            }
        }

        public TableQuery<Inv_Evo> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Inv_Evo>();
        }

        public void Editar(Inv_Evo entidade)
        {
            throw new NotImplementedException();
        }

        public Inv_Evo ObterDados()
        {
            throw new NotImplementedException();
        }

        public Inv_Evo ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Inv_Evo> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }

        TableQuery<Inv_Evo> IRepository<Inv_Evo>.AsQueryable()
        {
            throw new NotImplementedException();
        }
    }
}
