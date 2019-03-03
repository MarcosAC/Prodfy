using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InventarioRepository : IRepository<Contagem>
    {
        private DataBase _dataBase;

        public InventarioRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Contagem>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Contagem entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Contagem> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            _dataBase._conexao.Execute("Delete From Contagem"); ;
        }

        public void Editar(Contagem entidade)
        {
            throw new NotImplementedException();
        }

        public Contagem ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Contagem> ObterTodos()
        {
            return _dataBase._conexao.Table<Contagem>().OrderBy(c => c.idContagem).ToList();
        }
    }
}
