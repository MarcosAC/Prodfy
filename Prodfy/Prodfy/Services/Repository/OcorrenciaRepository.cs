using Prodfy.Helpers;
using Prodfy.Models;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class OcorrenciaRepository
    {
        private readonly DataBase _dataBase;

        public OcorrenciaRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var total = _dataBase._conexao.Table<Monit_Ocorr>().Count();

            if (total > 0)
                return total;

            return 0;
        }

        public void DeletarTodos()
        {
            _dataBase._conexao.Execute("Delete From Monit_Ocorr");
        }

        public List<Monit_Ocorr> ObterTodos()
        {
            return _dataBase._conexao.Table<Monit_Ocorr>().OrderBy(o => o.idMonit_Ocorr).ToList();
        }
    }
}
