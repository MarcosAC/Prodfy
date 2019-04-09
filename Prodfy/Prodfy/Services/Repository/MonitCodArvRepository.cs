using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MonitCodArvRepository : IRepository<Monit_Cod_Arv>
    {
        private DataBase _dataBase;

        public MonitCodArvRepository()
        {
            _dataBase = new DataBase();
        }

        public int ObterTotalDeRegistros()
        {
            var totalRegistro = _dataBase._conexao.Table<Monit_Cod_Arv>().Count();

            if (totalRegistro > 0)
                return totalRegistro;

            return 0;
        }

        public void Adicionar(Monit_Cod_Arv entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Monit_Cod_Arv> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar()
        {
            throw new NotImplementedException();
        }

        public void Editar(Monit_Cod_Arv entidade)
        {
            throw new NotImplementedException();
        }

        public Monit_Cod_Arv ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Monit_Cod_Arv> ObterTodos()
        {
            throw new NotImplementedException();
        }        
    }
}
