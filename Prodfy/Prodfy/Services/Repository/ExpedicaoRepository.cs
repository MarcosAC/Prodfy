using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ExpedicaoRepository : IRepository<Expedicao>
    {
        private DataBase _dataBase;

        public ExpedicaoRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Expedicao>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Expedicao entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Expedicao> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From Expedicao");
        }

        public void Editar(Expedicao entidade)
        {
            throw new NotImplementedException();
        }

        public Expedicao ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Expedicao> ObterTodos()
        {
            return _dataBase._conexao.Table<Expedicao>().OrderBy(e => e.idExpedicao).ToList();
        }

        public string ObterInformacoesParaIdentificacao(int codigo)
        {
            throw new NotImplementedException();
        }

        public Expedicao ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
