using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class PerdaRepository : IRepository<Perda>
    {
        private DataBase _dataBase;

        public PerdaRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Perda>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Perda entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Perda> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From Perda");
        }

        public void Editar(Perda entidade)
        {
            throw new NotImplementedException();
        }

        public Perda ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Perda> ObterTodos()
        {
            return _dataBase._conexao.Table<Perda>().OrderBy(p => p.idPerda).ToList();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Perda ObterDadosPorId(string id)
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

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }
    }
}
