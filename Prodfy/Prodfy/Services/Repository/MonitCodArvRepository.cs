using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MonitCodArvRepository : IRepository<Monit_Cod_Arv>
    {
        private DataBase dataBase;

        public MonitCodArvRepository()
        {
            dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = dataBase._conexao.Table<Monit_Cod_Arv>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public void Adicionar(Monit_Cod_Arv monit_Cod_Arv)
        {
            try
            {
                dataBase._conexao.Insert(monit_Cod_Arv);
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Erro", ex.Message, "OK");
            }
        }

        public TableQuery<Monit_Cod_Arv> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Monit_Cod_Arv entidade)
        {
            throw new NotImplementedException();
        }

        public Monit_Cod_Arv ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Monit_Cod_Arv> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Monit_Cod_Arv ObterDadosPorId(string id)
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
    }
}
