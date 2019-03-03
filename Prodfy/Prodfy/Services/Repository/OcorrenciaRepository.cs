using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class OcorrenciaRepository : IRepository<Monit_Ocorr>
    {
        private DataBase _dataBase;

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

        public void Adicionar(Monit_Ocorr entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Monit_Ocorr> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            _dataBase._conexao.Execute("Delete From Monit_Ocorr");
        }

        public void Editar(Monit_Ocorr entidade)
        {
            throw new NotImplementedException();
        }

        public Monit_Ocorr ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Monit_Ocorr> ObterTodos()
        {
            return _dataBase._conexao.Table<Monit_Ocorr>().OrderBy(o => o.idMonit_Ocorr).ToList();
        }
    }
}
