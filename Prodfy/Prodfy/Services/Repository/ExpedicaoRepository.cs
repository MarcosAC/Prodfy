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

        public void Deletar(Expedicao entidade)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
