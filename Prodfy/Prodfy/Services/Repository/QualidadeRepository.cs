using Prodfy.Helpers;
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            dataBase._conexao.DeleteAll<Qualidade>();
        }

        public void Editar(Qualidade entidade)
        {
            throw new NotImplementedException();
        }

        public Qualidade ObterDados()
        {
            throw new NotImplementedException();
        }

        public Qualidade ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(int id, string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Qualidade> ObterTodos()
        {
            var listaQualidade = dataBase._conexao.Query<Qualidade>("SELECT qualidade_id, codigo, titulo FROM Qualidade ORDER BY 2");
            return listaQualidade;
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
