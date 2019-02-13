﻿using Prodfy.Helpers;
using Prodfy.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace Prodfy.Services.Repository
{
    public class MedicaoRepository : IRepository<Monit_Med>
    {
        private DataBase _dataBase;

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

        public void Adicionar(Monit_Med entidade)
        {
            throw new NotImplementedException();
        }

        public TableQuery<Monit_Med> AsQueryable()
        {
            throw new NotImplementedException();
        }

        public void Deletar(Monit_Med entidade)
        {
            throw new NotImplementedException();
        }

        public void Editar(Monit_Med entidade)
        {
            throw new NotImplementedException();
        }

        public Monit_Med ObterDados()
        {
            throw new NotImplementedException();
        }

        public List<Monit_Med> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
