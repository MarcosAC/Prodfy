using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class LoteRepository : IRepository<Lote>
    {
        private DataBase _dataBase;

        public LoteRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = _dataBase._conexao.Table<Lote>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public void Adicionar(Lote entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Lote> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Lote entidade)
        {
            throw new NotImplementedException();
        }

        public Lote ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Lote> ObterTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
