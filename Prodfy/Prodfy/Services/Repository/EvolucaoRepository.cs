using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class EvolucaoRepository : IRepository<Evolucao>
    {
        private DataBase _dataBase;

        public EvolucaoRepository()
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

        public void Adicionar(Evolucao entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Evolucao> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(Evolucao entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(Evolucao entidade)
        {
            throw new NotImplementedException();
        }

        public Evolucao ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Evolucao> ObterTodos()
        {
            return _dataBase._conexao.Table<Evolucao>().OrderBy(e => e.idEvolucao).ToList();
        }
    }
}
