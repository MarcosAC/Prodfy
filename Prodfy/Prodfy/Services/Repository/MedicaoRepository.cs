using Prodfy.Helpers;
using Prodfy.Models;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MedicaoRepository
    {
        private readonly DataBase _dataBase;

        public MedicaoRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Monit_Med>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From Monit_Med");
        }

        public List<Monit_Med> ObterTodos()
        {
            return _dataBase._conexao.Table<Monit_Med>().OrderBy(m => m.idMonit_Med).ToList();
        }
    }
}
