using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class HistoricoRepository : IRepository<Historico>
    {
        private DataBase _dataBase;

        public HistoricoRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Evolucao>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Historico entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Historico> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            _dataBase._conexao.Execute("Delete From Historico");
        }

        public void Editar(Historico entidade)
        {
            throw new NotImplementedException();
        }

        public Historico ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Historico> ObterTodos()
        {
            return _dataBase._conexao.Table<Historico>().OrderBy(h => h.idHistorico).ToList();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
