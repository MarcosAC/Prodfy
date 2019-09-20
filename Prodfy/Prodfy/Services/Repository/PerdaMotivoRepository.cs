using Prodfy.Helpers;
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Perda_Motivo>();
        }

        public void Editar(Perda_Motivo entidade)
        {
            throw new NotImplementedException();
        }

        public Perda_Motivo ObterDados()
        {
            throw new NotImplementedException();
        }

        public Perda_Motivo ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterLoteInfo(string codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterMudaInfo(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Perda_Motivo> ObterTodos()
        {
            return dataBase._conexao.Query<Perda_Motivo>("SELECT perda_motivo_id, motivo FROM Perda_Motivo ORDER BY 2");
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
