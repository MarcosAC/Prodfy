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

        public void Deletar(Perda entidade)
        {
            throw new NotImplementedException();
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
    }
}
