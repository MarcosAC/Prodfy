using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MedicaoRepository : IRepository<Monit_Med>
    {
        private DataBase _dataBase;

        public MedicaoRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Monit_Med>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Monit_Med entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Monit_Med> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From Monit_Med");
        }

        public void Editar(Monit_Med entidade)
        {
            throw new NotImplementedException();
        }

        public Monit_Med ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Monit_Med> ObterTodos()
        {
            return _dataBase._conexao.Table<Monit_Med>().OrderBy(m => m.idMonit_Med).ToList();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Monit_Med ObterDadosPorId(string id)
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
