using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InventarioRepository : IRepository<Inventario>
    {
        private DataBase _dataBase;

        public InventarioRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Inventario>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void Adicionar(Inventario entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Inventario> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            _dataBase._conexao.Execute("Delete From Contagem"); ;
        }

        public void Editar(Inventario entidade)
        {
            throw new NotImplementedException();
        }

        public Inventario ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Inventario> ObterTodos()
        {
            return _dataBase._conexao.Table<Inventario>().OrderBy(i => i.idInventario).ToList();
        }

        public string ObterInformacoesParaIdentificacao(string codigo)
        {
            throw new NotImplementedException();
        }

        public Inventario ObterDadosPorId(string id)
        {
            throw new NotImplementedException();
        }
    }
}
