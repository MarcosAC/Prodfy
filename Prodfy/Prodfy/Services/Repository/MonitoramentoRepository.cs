using Prodfy.Helpers;
using Prodfy.Models;

namespace Prodfy.Services.Repository
{
    public class MonitoramentoRepository
    {
        private readonly DataBase _dataBase;

        public MonitoramentoRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = _dataBase._conexao.Table<Monit>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }        
    }
}
