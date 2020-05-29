using Prodfy.Helpers;
using Prodfy.Models;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class ExpedicaoRepository
    {
        private readonly DataBase _dataBase;

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

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From Expedicao");
        }

        public List<Expedicao> ObterTodos()
        {
            return _dataBase._conexao.Table<Expedicao>().OrderBy(e => e.idExpedicao).ToList();
        }
    }
}
