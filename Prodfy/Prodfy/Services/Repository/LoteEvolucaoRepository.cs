using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class LoteEvolucaoRepository : IRepository<Lote_Evolucao>
    {
        private DataBase dataBase;

        public LoteEvolucaoRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Lote_Evolucao lote_Evolucao)
        {
            try
            {
                dataBase._conexao.Insert(lote_Evolucao);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Lote_Evolucao> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Lote_Evolucao entidade)
        {
            throw new NotImplementedException();
        }

        public Lote_Evolucao ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Lote_Evolucao> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
