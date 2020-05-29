using Prodfy.Helpers;
using Prodfy.Models;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class InventarioRepository
    {
        private readonly DataBase _dataBase;

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

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From Contagem"); ;
        }

        public List<Inventario> ObterTodos()
        {
            return _dataBase._conexao.Table<Inventario>().OrderBy(i => i.idInventario).ToList();
        }
    }
}
