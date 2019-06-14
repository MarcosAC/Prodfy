using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MonitParcelaRepository : IRepository<Monit_Parcela>
    {
        private DataBase dataBase;

        public MonitParcelaRepository()
        {
            dataBase = new DataBase();
        }

        public void Adicionar(Monit_Parcela monit_Parcela)
        {
            try
            {
                dataBase._conexao.Insert(monit_Parcela);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Monit_Parcela> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            throw new NotImplementedException();
        }

        public void Editar(Monit_Parcela entidade)
        {
            throw new NotImplementedException();
        }

        public Monit_Parcela ObterDados()
        {
            throw new NotImplementedException();
        }

        public Monit_Parcela ObterDadosPorId(string id)
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

        public List<Monit_Parcela> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public int ObterTotalDeRegistros()
        {
            throw new NotImplementedException();
        }
    }
}
